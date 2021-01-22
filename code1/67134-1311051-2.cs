    public class WebApplicationErrorPage : IHttpHandler, IReadOnlySessionState {
        public bool IsReusable {
            get {
                return true;
            }
        }
        public void ProcessRequest(HttpContext context) {
            response.Clear();
            response.ContentEncoding = Encoding.UTF8;
            response.ContentType = "text/html";
            response.Write((string) context.Session["ErrorPageText"]);
            response.Flush();
        }
    }
