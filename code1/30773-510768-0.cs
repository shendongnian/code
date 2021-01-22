    SynchronizationContext context;
    
    void start()
    {
        //First store the current context
        //to call back to it later
        context = SynchronizationContext.Current; 
        
        //Start a thread and make it call
        //the async method, for example: 
        Proxy.BeginCodeLookup(aVariable, 
                        new AsyncCallback(LookupResult), 
                        AsyncState);
        //Now continue with what you were doing 
        //and let the lookup finish
    }
    void LookupResult(IAsyncResult result)
    {
        //when the async function is finished
        //this method is called. It's on
        //the same thread as the the caller,
        //BeginCodeLookup in this case.
        result.AsyncWaitHandle.WaitOne();
        var LookupResult= Proxy.EndCodeLookup(result);
        //The SynchronizationContext.Send method
        //performs a callback to the thread of the 
        //context, in this case the main thread
        context.Send(new SendOrPostCallback(OnLookupCompleted),
                     result.AsyncState);                         
    }
    void OnLookupCompleted(object state)
    {
        //now this code will be executed on the 
        //main thread.
    }
