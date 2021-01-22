    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
     
    namespace SilverlightApplication1.Web
    {
        /// <summary>
        /// Summary description for WebService1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        public class WebService1 : System.Web.Services.WebService
        {
            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World";
            }
        }
    }
