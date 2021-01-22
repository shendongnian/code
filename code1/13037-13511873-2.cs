        [System.Web.Script.Services.ScriptService]
        public class WebServiceClass : System.Web.Services.WebService {
            [WebMethod]
            public void WebMethodName()
            {
                HttpContext.Current.Response.Write("{property: value}");
            }
        }
