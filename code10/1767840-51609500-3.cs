    public async Task MyTestAndWait(CancellationToken ct)
    {
        await Task.Delay(5000,ct);
        var waitCount=0;
        while(!ct.IsCancellationRequested && waitCount++ < 15 && !(await DoStopTest()))
        {
            await Task.Delay(10000,ct);
        }
        MessageBox.Show("Poll stopped!");
    }
