    public delegate void MyAwesomeEventHandler(int rawr);
    public event MyAwesomeEventHandler AwesomeJump;
    public event EventHandler Jump;
    
    public void OnJump()
    {
        AwesomeJump?.Invoke(42);
        Jump?.Invoke(this, EventArgs.Empty);
    }
