    protected override async void OnAppearing()
    {
        base.OnAppearing();
    
        if (task != null && (task.Status == TaskStatus.Running || task.Status == TaskStatus.WaitingToRun || task.Status == TaskStatus.WaitingForActivation))
        {
            Debug.WriteLine("Task has attempted to start while already running");
        }
        else
        {
            Debug.WriteLine("Task has began");
    
            var token = tokenSource.Token;
            PageLoading();
            var r = await GetDataAsync(token);
            if (r == "OK")
            {
                GetDataSuccess();
            }
       }      
    }
    public async Task GetData(CancellationToken token)
    {
        WebAPI api = new WebAPI();
        if (token.IsCancellationRequested)
        {
            token.ThrowIfCancellationRequested();
        }
        try
        {
            return await api.GetProfileStatus(token);
        }
        catch (Exception e)
        {
            // log exception and return error
            return "Error";
        }
    }
