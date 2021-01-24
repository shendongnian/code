    async Task<string> MySendMethod(MailMessage email)
    {
        var client = new MailKit.Net.Smtp.SmptClient();
        //Configure the client here ...
        try
        {
            var msg=(MailKit)email;
            await client.SendAsync(msg);
            return "";
        }
        catch(Exception ex)
        {
            _log.Error(ex);
            switch (ex)
            {
                case SmtpFailedRecipientException f:
                    return $"Failed to send to {f.FailedRecipient}"; 
                case SmptException s :
                    return "Protocol error";
                default:
                    return "Unexpected error";
            }
        }
    }
