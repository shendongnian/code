    namespace MyCompany.Project.Services
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.Web.Script.Services.ScriptService]
        public class MyWebServiceClass : System.Web.Services.WebService
        {
        
            [WebMethod]
            public string GreetFromServer(string name)
            {
                return "Hello, " + name;
            }
        }
    }
