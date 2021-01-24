    // We need an interface so we can test your code from unit tests without actually emailing people
    public interface IEmailService
    {
        async Task SendMail();
    }
    
    public EmailService : IEmailService
    {
        public async Task SendMail()
        {
            // Perform the email sending here
        }
    }
    
    [Route("/api/[controller]")]
    public class SchedulersController : Controller
    {
        [HttpPost("appointments/new")]
        public IActionResult SendMailMinutely()
        {
            RecurringJob.AddOrUpdate<IEmailService>(service => service.SendMail(), Cron.Minutely);
            return Ok();
        }
    }
