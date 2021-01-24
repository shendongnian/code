    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        
       [Route("sendemail")]
       [HttpPost]
       public bool SendEmail(EmailObj email)
       {
           if(email !=null)
           {
               return true;
           }
           return false;
       }
       
    }
    public class EmailObj
    {
        public string sendTo { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
