    class OrderService : IOrderSerivce 
    {
        private IEmailService _mailer;
        public OrderService(IEmailService mailSvc) 
        {
            this. _mailer = mailSvc;
        }
    
        public void SubmitOrder(Order order) 
        {
            // other order-related code here
    
            System.Net.Mail.MailMessage confirmationEmail = ... // create the confirmation email
            _mailer.SendEmail(confirmationEmail);
        } 
    
    }
