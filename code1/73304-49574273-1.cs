    namespace foo
    {
        /// <summary>
        /// Summary description for TestService
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.None)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
        public class TestService : System.Web.Services.WebService
        {
    
            [WebMethod(MessageName = "HelloWorld1")]
            public string HelloWorld()
            {
                return "Hello World";
            }
    
            [WebMethod(MessageName = "HelloWorld2")]
            public string HelloWorld(string Value = "default")
            {
                return "Hello World";
            }
        }
    }
