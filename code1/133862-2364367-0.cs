    private IMessage _next;
    
    public void ReceiveMessage(IMessage message)
    {
        Interlocked.Exchange(ref _next, message);
    }
    
    public void Process()
    {
        IMessage next = Interlocked.Exchange(ref _next, null);
    
        if (next != null)
        {
            //...
        }
    }
