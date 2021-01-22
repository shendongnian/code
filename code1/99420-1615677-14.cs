    public class MyWebSevice : System.Web.Services.WebService
    {
        private AuthenticationService _auth = new AuthenticationService ();
        private int _count = 0;
        [WebMethod]
        public string DoSomething ()
        {
            // embedded business logic, bad bad bad
            if (_auth.Authenticate ())
            {
                _count++;
            }
            return count.ToString ();
        }
    }
