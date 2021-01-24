    public async Task ExecuteSlowOperationAsync(..., CancellationToken token)
    {
        while (true)
        {
            if(cancelToken.IsCancellationRequested)
            {
                return;
            }
            ...
        }
    }
