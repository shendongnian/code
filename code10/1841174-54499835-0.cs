    using UnityEngine;
    public class PlayerController : MonoBehaviour
    {
    private float speed = 3f;
    private Animator anim;
    private SpriteRenderer sr;
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * (h * speed * Time.deltaTime));
        anim.SetBool("Walk", h != 0f);
        if (anim.GetBool("Walk"))
            Flip(h > 0f);
    }
    void Flip(bool facingRight)
    {
        sr.flipX = !facingRight;
    }
    }
