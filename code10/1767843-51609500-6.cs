    public async Task MyTestAndWait()
    {
        await Task.Delay(5000);
        var waitCount=0;
        while( waitCount++ < 15 && !(await DoStopTest()))
        {
            await Task.Delay(10000);
        }
        MessageBox.Show("Thread stopped!");
    }
