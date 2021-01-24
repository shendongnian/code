    CancellationTokenSource _cts;
    public async void SendSMS_Click(object sender, EventArgs args)
    {
        DisableSending();
        var phone=txtPhone.Text;
        var message=txtMessage.Text;
        _cts=new CancellationTokenSource(TimeSpan.FromMinutes(15);
        var (ok,reason)=await _smsService.SendSmsAsync(phone,message,cts.Token);       
        _cts=null;
       
        if (ok)
        {
            MessageBox.Show("OK");
        }
        else
        {
            MessageBox.Show($"Failed: {reason}");
        }
        EnableSending();
    }
    public void EnableSending()
    {
        SendSMS.Enabled=true;
        Cancel.Enabled=false;    
    }
    public void DisableSending()
    {
        SendSMS.Enabled=false;
        Cancel.Enabled=true;    
    }
