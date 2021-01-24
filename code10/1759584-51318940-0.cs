    public interface IMySms
    {
        Task<bool> SendSms(string to = null, string message = null);
    }
    
    public Task<bool> SendSms(string to = null, string message = null)
    {
        //Create an instance of TaskCompletionSource, which returns the true/false
        var tcs = new TaskCompletionSource<bool>();
    
        if (MFMessageComposeViewController.CanSendText)
        {
            MFMessageComposeViewController smsController = new MFMessageComposeViewController();
   
            // ...Your Code...             
            //This event will set the result = true if sms is Sent based on the value received into e.Result enumeration
            smsController.Finished += (sender, e) =>
            {
                 bool result = e.Result == MessageComposeResult.Sent;
                 //Set this result into the TaskCompletionSource (tcs) we created above
                 tcs.SetResult(result);
            };
        }
        else
        {
            //Device does not support SMS sending so set result = false
            tcs.SetResult(false);
        }
        return tcs.Task;
    }
