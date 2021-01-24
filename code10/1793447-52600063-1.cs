    public class BasicAuthenticationMiddleWare : OwinMiddleware
    {
        public BasicAuthenticationMiddleWare(OwinMiddleware next) : base(next) { }
        
        public override Task Invoke(IOwinContext context)
        {
            throw new NotImplementedException();
        }
    }
