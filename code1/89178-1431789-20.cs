    public class SessionHeartbeatHttpHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable { get { return false; } }
    
        public void ProcessRequest(HttpContext context)
        {
            context.Session["Heartbeat"] = DateTime.Now;
        }
    }
