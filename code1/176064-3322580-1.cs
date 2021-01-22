    public IDictionary<string, int> DoSomething(string startsWith)
    {
        return new Dictionary<string, int>();
    }
    
    public IAsyncResult BeginDoSomething(string startsWith, AsyncCallback callback,
                                         object state)
    {
        var doSomething = new Func<string, IDictionary<string, int>>(DoSomething);
    
        return doSomething.BeginInvoke(startsWith, callback, new object[] { doSomething, state });
    }
    
    public IDictionary<string, int> EndDoSomething(IAsyncResult result)
    {
        var doSomething = (Func<string, IDictionary<string, int>>)((object[])result.AsyncState)[0];
    
        return doSomething.EndInvoke(result);
    }
