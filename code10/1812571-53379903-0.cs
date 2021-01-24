    bool m_IsGrounded;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            m_IsGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            m_IsGrounded = false;
    }
    void Update()
    {
        if (m_IsGrounded)
        {
            Debug.Log("Grounded");
        }
    }
