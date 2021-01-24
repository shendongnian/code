    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        EmailSettings _emailSettings;
        public ValuesController(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
    ....
    }
