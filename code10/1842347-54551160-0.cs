    public class EmailController : Controller
    {
      private IEmailSendingService emailService;
      private IUserService userService;
      private ILoggingService loggingService
    
      public EmailController(IEmailService mailSrvc, IUserservice usrSvc, ILoggingService log)
      {
          this.emailService = mailSrvc;
          this.userService = usrSvc;
          this.loggingService = log;
      }
      public ActionResult SendEmail()
      {
          var emailAddress = this.userService.GetEmail(...);
          this.emailService.SendEmail(emailAddress);
          ... use logger ...
          ... return whats needed ...
      }
    }
