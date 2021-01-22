    // this web service is now a consumer of a business class,
    // no embedded logic, so does not require direct testing
    public class MyWebSevice : System.Web.Services.WebService
    {
        private readonly MyService _service = new MyService ();
        [WebMethod]
        public string DoSomething ()
        {
            _service.DoSomething ();
        }
    }
