        public class EnableRewindResourceFilterAttribute : Attribute, IResourceFilter
        {
            public void OnResourceExecuted(ResourceExecutedContext context) { }
            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                context.HttpContext.Request.EnableRewind();
            }
        }
