    [RoutePrefix("api/sendSms")]
    public class SendSmsController : Controller
    {
        [Route]    
        public string Get(string id, string pass)
        {
            return id + pass;
        }
    }
