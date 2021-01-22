    public class Service1 : System.Web.Services.WebService
    {
        private static List<CustomConnection> _connections = 
            new List<CustomConnection>();
    
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
