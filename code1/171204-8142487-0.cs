    //Fuse all Receivers
    var allRecipients = String.Join(",", recipients);
    
    //Create new mail
    var mail = new MailMessage(sender, allRecipients, subject, body);
    
    //Create new SmtpClient
    var smtpClient = new SmtpClient(hostname, port);
    
    //Try Sending The mail
    try
    {
        smtpClient.Send(mail);
    }
    catch (Exception ex)
    {
        Log.Error(String.Format("MailAppointment: Could Not Send Mail. Error = {0}",ex), this);
        return false;
    }
