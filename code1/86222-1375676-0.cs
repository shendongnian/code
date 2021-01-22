    public class MyHttpHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            var MyValue = context.Session["MyKey"] as String;
            
            MyValue = "Hello World";
            context.Session["MyKey"] = MyValue;
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
