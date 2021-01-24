    public Task<string> ConnectAsync(ThatService service)
    {
        if (service==null) 
            throw new ArgumentNullException(nameof(service));
        var tcs=new TaskCompletionSource<string>();
        service.ConnectResultHandler=(ok,msg)=>
        {
            if(ok)
            {
                tcs.TrySetResult(msg);
            }
            else
            {
                tcs.TrySetException(new Exception(msg));
            }
        };
        
        return tcs.Task;
    }
