    public IDictionary<string, int> DoSomething(string startsWith) 
    { 
      return new Dictionary<string, int>(); 
    } 
 
    public IAsyncResult BeginDoSomething(string startsWith, AsyncCallback callback, 
                                         object state) 
    {
      return Task.Factory.StartNew(_ => { return DoSomething(startsWith); }, state);
    } 
 
    public IDictionary<string, int> EndDoSomething(IAsyncResult result) 
    {
      var task = (Task<IDictionary<string, int>>)result;
      return task.Result;
    } 
