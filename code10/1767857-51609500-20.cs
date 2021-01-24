    //In an SmsService class
    public async Task<(bool ok,string msg)> SendSmsAsync(string phone,string message,CancellationToken ct)
    {
        var smsMsg=BuildSmsContent(phone,string);
        await _httpClient.PostAsync(smsMsg,ct);
      
        //wait before polling
        await Task.Delay(_initialDelay,ct);
        for(int i=0;i<15 && !ct.IsCancellationRequested;i++)
        {
            var checkMsg=CheckStatusContent(phone,string);
            var response=await _httpClient.GetAsync(check,ct);
            
            if (ct.IsCancellationRequested) break;
         
            //Somehow check the response. Assume it has a flag and a Reason
            var status=ParseTheResponse(response);
            switch(status.Status)
            {
                case Status.OK:
                    return (ok:true,"Sent");
                case Status.Error:
                    return (ok:failed,status.Reason);
                case Status.Pending:
                    await Task.Delay(_pollDelay,ct);
                    break;
            }
        }
        return (ok:false,"Exceeded retries or cancelled");    
    }
