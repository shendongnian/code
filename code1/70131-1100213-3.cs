        [WebService(... )]
        public class BusinessProcess : System.Web.Services.WebService
        {
            [WebMethod]
            public HelloWorldObject helloWorld()
            {
                return new HelloWorldObject("Earth");
            }
        }
