    public class MyClass
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public MyClass (IHttpContextAccessor contextAccessor)
        { 
             _contextAccessor = contextAccessor;
        }
    
        public void MyFunction()
        {
             var someCookie = _contextAccessor.HttpContext.Request.Cookies["someCookie"];
        }
    }
