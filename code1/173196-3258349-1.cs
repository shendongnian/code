    public void SendNotification( string smtpHost, string recipientAddress, string senderAddress, string message, string subject )
    {
    	SmtpClient  mailClient = new SmtpClient(smtpHost);
    	MailMessage   emailMsg = new MailMessage( new MailAddress(senderAddress), new MailAddress(recipientAddress) );
    	
    	emailMsg.Subject = subject;
    	emailMsg.Body = message;
    	
    	mailClient.Send( emailMsg );
    }
