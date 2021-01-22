        [ScriptService]
        public class WebService1 : System.Web.Services.WebService 
        {
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public string HelloAndroid()
            {
                return "Hello Android";
            }
        }
