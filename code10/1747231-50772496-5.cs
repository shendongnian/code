    public class SendSmsController : Controller
    {
        public string Get(string id, string pass)
        {
            return id + pass;
        }
    }
