    public delegate void MyHandler;
    public event MyHandler _MyEvent
    public int GetInvocationListLength()
    {
       var d = this._MyEvent.GetInvocationList(); //Delegate[]
       return d.Length;
    }
    
