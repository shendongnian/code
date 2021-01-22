    public event Error;
    public event Success;
    
    protected void OnError()
    {
        if(Error != null)
            Error();
    }
    
    protected void OnSuccess()
    {
        if(Success != null)
            Success();
    }
