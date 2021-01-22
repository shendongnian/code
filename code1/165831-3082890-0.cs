    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RateLimitAttribute : ActionFilterAttribute
    {
        public int Seconds { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Using the IP Address here as part of the key but you could modify
            // and use the username if you are going to limit only authenticated users
            // filterContext.HttpContext.User.Identity.Name
            var key = string.Format("{0}-{1}-{2}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName,
                filterContext.HttpContext.Request.UserHostAddress
            );
            var allowExecute = false;
            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key,
                    true,
                    null,
                    DateTime.Now.AddSeconds(Seconds),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null);
                allowExecute = true;
            }
            if (!allowExecute)
            {
                filterContext.Result = new ContentResult
                {
                    Content = string.Format("You can call this every {0} seconds", Seconds)
                };
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            }
        }
    }
