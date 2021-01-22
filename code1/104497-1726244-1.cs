        /// <summary>
        /// Summary description for WebService1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [ToolboxItem(false)]
        public class WebService1 : System.Web.Services.WebService
        {
            public Auth auth;
            [WebMethod]
            [SoapHeader("auth")]
            public string HelloWorld()
            {
        
                return auth.usr;
            }
        }
    
        public class Auth : SoapHeader
        {
            public string usr;
        }
