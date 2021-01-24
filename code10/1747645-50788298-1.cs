    private Rigidbody rb;
    public float jumpForce = 20f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        bool player_jump = Input.GetButtonDown("DefaultJump");
    
        if (player_jump && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    
    bool IsGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 10;
        //Raycast to to the floor objects only
        int mask = 1 << LayerMask.NameToLayer("Ground");
    
        //Raycast downwards
        if (Physics.Raycast(transform.position, Vector3.down, out hit,
            raycastDistance, mask))
        {
            return true;
        }
        return false;
    }
