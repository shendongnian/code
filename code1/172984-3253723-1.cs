    delegate void SendMailAsync(params object[] args);
    
    static void Main()
    {
        SendMailAsync del = new SendMailAsync(SendMail);
        del.BeginInvoke(new object[] { "emailAddress" }, null, null);
    }
    
    static void SendMail(params object[] args)
    {
        // Send
    }
