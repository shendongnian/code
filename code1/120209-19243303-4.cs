    <%@ WebService Language="C#" Class="WebService" %>
    using System;
    using System.Collections.Generic;
    using System.Web.Services;
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService {
        [WebMethod]
        public MyClass Example()
        {
            return new MyClass();
        }
    
        public class MyClass
        {
            public string Message { get { return "Hi"; } }
            public int Number { get { return 123; } }
            public List<string> List { get { return new List<string> { "Item1", "Item2", "Item3" }; } }
        }
    }
