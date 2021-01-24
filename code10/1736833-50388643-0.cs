    public void StartObserving()
    {
        this.cts = new CancellationTokenSource();
        var token = this.cts.Token;
    
        Task.Run(async () =>
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var result = this.serviceAPI.GetStatus();
                    this.OnServiceStatusChanged(result);
                    await Task.Delay(3000);
                }
            }
            catch
            {
            }
        });
    }
