    public Task<bool> ConnectAsync(ThatService service)
    {
        if (service==null) 
            throw new ArgumentNullException(nameof(service));
        var tcs=new TaskCompletionSource<bool>();
        service.ConnectResultHandler=(ok,msg)=>
        {
            if(ok)
            {
                tcs.TrySetResult(true);
            }
            else
            {
                tcs.TrySetException(new Exception(msg));
            }
        };
        
        return tcs.Task;
    }
