    namespace com.waynehartman.util.web.handlers
    {
        [WebService(Namespace = "http://waynehartman.com/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class HttpCompressor : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                // Code for compressing the file and writing it to the HttpResponse
            }
            public bool IsReusable
            {
                get { return true; }
            }
        }
    }
