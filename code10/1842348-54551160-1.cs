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
        try
        {
          var emailAddress = this.userService.GetEmail(...);
          if(..validate email address, maybe through another service..)
          {
              this.emailService.SendEmail(emailAddress);
          }          
        }
        catch(MailNotFoundException ex)
        {
          this.loggingService.LogError("Email address not found for xy user");
          return NotFound();
        }
        catch(EmailSendingFailedException ex)
        {
          this.loggingService.LogError("Could not send email because xyz");
          ... return internalservererror etc. ...
        }
        catch(Exception ex)
        {
          this.loggingService.LogError("...");
        }          
          
          ... return whats needed ...
      }
    }
