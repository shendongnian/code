    public class FooBarController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly System.Web.HttpRequestBase _request;
    
        public FooBarController(System.Web.HttpRequestBase request)
        {
            _request = request;
        }
    }
