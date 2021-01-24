    public class DbConnectionInfo
    {
        public string MyContext { get; set; }
        // Example injecting IHttpContextAccessor
        // On creating this class DI will inject 
        // the HttpContextAccessor as parameter
        public DbConnectionInfo(IHttpContextAccessor httpContextAccessor)
        {
            // Access the current request
            var request = httpContextAccessor.HttpContext.Request;
            // Access the current user (if authenticated)
            var user = httpContextAccessor.HttpContext.User;
            // Now you could get a value from a header, claim,
            // querystring or path and use that to set the value:
            MyContext = "";
        }
     }
