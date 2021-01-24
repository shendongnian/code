    public void Start() {
    
        using (var mail = new MailMessage {
            From = new MailAddress(sender),
            Subject = "test subject",
            Body = "Hello there!"}) 
        {
    
            mail.To.Add(receiver);
    
            var smtpServer = new SmtpClient(smtpHost) {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
    
                Credentials = (ICredentialsByHost) new NetworkCredential(sender, smtpPassword)
            };
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            try {
        	    smtpServer.Send(mail);
        	}  
        	catch (Exception ex) {
        	    Console.WriteLine("Exception while smtpServer.Send(mail): {0}", 
                          ex.ToString() );			  
            }    
        }
    }
