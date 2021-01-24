        public bool IsGrounded()
    {
        return CoyoteTime < CoyoteTimeMax;
    }
    public void CoyoteControl()
    {
        if (CharController.isGrounded)
        {
            CoyoteTime = 0;
        }
        else
        {
            CoyoteTime += Time.deltaTime;
        }
    }
