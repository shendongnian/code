    public class VoiceController : Controller
    {
        [HttpPost]
        public ActionResult Index(string to)
        {
            var callerId = ConfigurationManager.AppSettings["TwilioCallerId"];
    
            var response = new VoiceResponse();
    
            if (!string.IsNullOrEmpty(to))
            {
                var dial = new Dial(callerId: callerId);
    
                // wrap the phone number or client name in the appropriate TwiML verb
                // by checking if the number given has only digits and format symbols
                if (to.Contains(myPhoneNumber))
                {
                    dial.Client("Jose"); // this works!
                }
                else if (Regex.IsMatch(to, "^[\\d\\+\\-\\(\\) ]+$"))
                {
                    dial.Number(to);
                }
                else
                {
                    dial.Client(to);
                }
    
                response.Dial(dial);
            }
            else
            {
                var dial = new Dial(callerId: callerId);
                dial.Number("+15555557898");
    
                response
                    .Say("Transferring your call to the Twilio client, Jose.")
                    .Dial(dial);
            }
    
            return Content(response.ToString(), "text/xml");
        }
    }
