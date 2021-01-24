    public class MySession {
        IHttpContextAccessor accessor;
        
        public MySession(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
        
        public void Foo() {
            var httpContext = accessor.HttpContext;
            httpContext.Session.SetString("Name", "The Doctor");
            httpContext.Session.SetInt32("Age", 773);
        }
    }
