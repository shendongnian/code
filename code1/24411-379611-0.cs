    private readonly int result;
    private readonly int message;
    
    public Result(bool result, string message)
    {
       this.result = result;
       this.message = message;
    }
    
    public int Result
    {
       get{ return result; }
       private set { result = value; }
    }
    
    public int Message
    {
       get{ return message; }
       private set { message = value; }
    }
