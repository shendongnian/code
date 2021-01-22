        [WebService]
        [ScriptService]
        public class MyWebService : System.Web.Services.WebService 
        {
            [WebMethod]
            public int SomeCallbackFunction() 
            { .... }
        }
