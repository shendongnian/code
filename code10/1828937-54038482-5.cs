    public Task<MyResultObject> DoSomeWork()
    {
         MyResultObject result = new MyResultObject();
         // Some work to be done here
    
         return Task.FromResult(result);
    }
