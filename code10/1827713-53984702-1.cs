    using UnityEngine;
    public class Player : MonoBehaviour
    {
    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sprite;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        _rb.velocity = movement * _speed;
            
        _anim.SetBool("Moving", horizontal != 0);
        if (horizontal != 0)
            Flip(horizontal > 0);
    }
    private void Flip(bool facingRight)
    {
        _sprite.flipX = !facingRight;
    }
    }
