    public event EventHandler Jump = delegate { };
    
    public void OnJump()
    {
        Jump(this, EventArgs.Empty);
    }
