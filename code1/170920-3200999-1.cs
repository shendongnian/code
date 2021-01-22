    private readonly object sync = new object();
    private List<object> list = new List<object>();
    
    void MultiThreadedMethod(object val)
    {
        lock(sync)
        {
            list.Add(val);
        }
    }
