    class EmailService : IEmailService {
        private SmtpClient client;
    
        public EmailService() {
            client = new SmtpClient();
            object settings = ConfigurationManager.AppSettings["SMTP"];
            // assign settings to SmtpClient, and set any other behavior you 
            // from SmtpClient in your application, such as ssl, host, credentials, 
            // delivery method, etc
        }
    
        public void SendEmail(MailMessage message) {
            client.Send(message);
        }
    
    }
