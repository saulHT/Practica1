using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caballero : MonoBehaviour
{
    public float velocityX = 10;
    public float jumpforce = 30;

    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private Animator animator;

    private const int Animation_idle = 0;
    private const int Animation_caminar = 1;
    private const int Animation_correr = 2;
    private const int Animation_saltar = 3;
    private const int Animation_atacar = 4;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        changeAnimation(Animation_idle);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX,rb.velocity.y);
            sp.flipX = false;
            changeAnimation(Animation_caminar);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sp.flipX = true;
            changeAnimation(Animation_caminar);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow))
        {
          
            changeAnimation(Animation_correr);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            changeAnimation(Animation_saltar);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            changeAnimation(Animation_atacar);
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado",animation);
    }
}
