    namespace MyCompany.Project.Services
    {
        [System.Web.Script.Services.ScriptService]
        public class MyWebServiceClass
        {
        
            [WebMethod]
            public string GreetFromServer(string name)
            {
                return "Hello, " + name;
            }
        }
    }
