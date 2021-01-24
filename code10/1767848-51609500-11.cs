    public async Task MyTestAndWait(CancellationToken ct,int initialDelay,int pollDelay)
    {
        await Task.Delay(initialDelay,ct);
        var waitCount=0;
        while(!ct.IsCancellationRequested && waitCount++ < 15 && !(await DoStopTest()))
        {
            await Task.Delay(pollDelay,ct);
        }
        MessageBox.Show("Poll stopped!");
    }
