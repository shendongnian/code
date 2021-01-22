    public class MyOrderConfirmService : IOrderConfirmService
    {    
        private readonly IEmailService _mailer;
        
        public MyOrderConfirmService(IEmailService mailer)
        {        
            _mailer = mailer;        
        }
        
        public void EmailOrderConfirmation(Order order)
        {        
            var msg = ConvertOrderToMessage(order); //good extension method candidite
            _mailer.Send(msg);        
        }    
    }
