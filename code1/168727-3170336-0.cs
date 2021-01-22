    public object A()
    {
        return new { Name = "Cid" }
    }
    
    public object B()
    {
        return new { Name = "Galuf" }
    }
    public void Test()
    {
       System.Diagnostics.Trace.Assert(A().GetType() == B().GetType());
    }
