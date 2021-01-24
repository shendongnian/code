    CancellationTokenSource _cts;
    public async void SendSMS_Click(object sender, EventArgs args)
    {
        SendSMS.Enabled=false;
        Cancel.Enabled=true;
        _cts=new CancellationTokenSource(TimeSpan.FromMinutes(15);
        await MyTestAndAwait(cts.Token);       
        _cts=null;
        SendSMS.Enabled=true;
        Cancel.Enabled=false;    
    }
    public async void Cancel_Click(object sender, EventArgs args)
    {
        _cts?.Cancel();
    }
