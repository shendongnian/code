    public class EmailController : Controller
    {
      // Interface segregation applied
      private IEmailSendingService emailService;
      private IUserService userService;
      private ILoggingService loggingService
    
      // Dependency inversion principle / Dependency injection applied
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
          // validate email address, maybe through another service
          if(Validator.ValidateEmail())
          {
              // Single responsibility applied
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
          // return internalservererror etc.
        }
        catch(Exception ex)
        {
          this.loggingService.LogError("...");
        }          
          
          // return whats needed
      }
    }
