    class MockEmailService : IEmailService {
        private EmailMessage sentMessage;;
    
        public SentMailMessage { get { return sentMessage; } }
    
        public void SendEmail(MailMessage message) {
            sentMessage = message;
        }
    
    }
