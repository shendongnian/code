        protected IHttpHandler Handler()
        {
            MyHttpHandler resourceHttpHandler = HttpContext.Current.Handler
                as MyHttpHandler;
            if (resourceHttpHandler != null) // set the original handler back 
            {                
                return resourceHttpHandler.OriginalHandler;
            }
            // at this point session state should be available      
            return HttpContext.Current.Handler;
        }
        public class MyHttpHandler : IHttpHandler, IRequiresSessionState
        {
            internal readonly IHttpHandler OriginalHandler;
            public MyHttpHandler(IHttpHandler originalHandler)
            {
                OriginalHandler = originalHandler;
            }
            public void ProcessRequest(HttpContext context)
            {
                // do not worry, ProcessRequest() will not be called,
                // but let's be safe         
                throw new InvalidOperationException(
                    "MyHttpHandler cannot process requests.");
            }
            public bool IsReusable
            {
                // IsReusable must be set to false since class has a member!
                get { return false; }
            }
        }
