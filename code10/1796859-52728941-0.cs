    using System.Web;
    using System.Web.SessionState;
    namespace WebApplication
    {
        public class RetainSession : IHttpHandler, 
            IRequiresSessionState
        {
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Ok");
            }
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
