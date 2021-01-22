    private readonly bool result;
    private readonly string message;
    
    public Answer(bool result, string message)
    {
       this.result = result;
       this.message = message;
    }
    
    public bool Result
    {
       get{ return result; }
       private set { result = value; }
    }
    
    public string Message
    {
       get{ return message; }
       private set { message = value; }
    }
