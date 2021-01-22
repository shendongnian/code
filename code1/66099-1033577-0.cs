    public class MyController
    {
        IEmailService _emailService;
        
        public MyController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public ActionResult Email()
        {
            var myMessage = new MyMessage();
            // Initialize message here
            _emailService.Enqueue(myMessage);
            return View();
        }
    }
