    public Task<MyResultObject> DoSomeWork()
    {
         return Task.Run(() =>
         {
             MyResultObject result = new MyResultObject();
             // Some work to be done here
    
             return result;
         });
    }
