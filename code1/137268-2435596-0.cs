    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    
    namespace MyNamespace.Newstuff.Webservice
    {
        [WebService(Namespace = "http://iamsocool.com/MyNamespace/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [ScriptService]
        public class MyNamespace : System.Web.Services.WebService
        {
            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World";
            }
        }
    }
