    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IPFilterAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>Invoked during authization checks for page load</summary>
        /// <param name="filterContext">Context of call, contains request and so on</param>
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext?.HttpContext?.Request;
            if (request == null)
                throw new ArgumentNullException(nameof(filterContext));
            if (!CheckIPAddress(request.UserHostAddress))
                // Setting the Result property on filterContext stops processing.
                filterContext.Result = new HttpUnauthorizedResult("Address Forbidden");
        }
        /// <summary>Check if the supplied IP address is authorized to access this page</summary>
        /// <param name="addr">Client address to test</param>
        /// <returns>True if address is authorized, else false</returns>
        private bool CheckIPAddress(string addr)
        {
            // sample, just check if it's the localhost address
            return (addr == "127.0.0.1" || addr == "::1");
        }
    }
