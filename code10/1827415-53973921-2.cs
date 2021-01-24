    public class MyClass
    {
        private readonly HttpContext context;
    
        public RequestInformation(IHttpContextAccessor contextAccessor) 
        {
            this.context = contextAccessor.HttpContext;
        }
    
        public string GetSettionId()
        {
            return HttpContext.Session.Id;
        }
    }
