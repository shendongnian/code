    public static void funcTest (string sSubject, string sBody)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.To = XMLConfigReader.Email;
            msg.From = XMLConfigReader.From_Email;
            msg.Subject = sSubject;
            msg.body = sBody.Replace("\0", string.Empty);
        }
        catch (Exception ex) 
        {
            string sMessage = ex.Message;     
            log.Error(sMessage, ex);   
        }
    }
