    public class SomeService : ISomeService
    {
        private readonly HttpContextBase httpContext;
        public SomeService(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));
            this.httpContext = httpContext;
            // Session state is still null here...
        }
        public void DoSomething()
        {
            // At runtime session state is available.
            var session = httpContext.Session;
        }
    }
