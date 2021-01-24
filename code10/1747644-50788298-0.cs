    private Rigidbody rb;
    bool isGrounded = true;
    public float jumpForce = 20f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        bool player_jump = Input.GetButtonDown("DefaultJump");
    
        if (player_jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
