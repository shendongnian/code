    public class ETagActionFilter : IActionFilter
    {
        private readonly ITagProvider _tagProvider;
        public ETagActionFilter(ITagProvider tagProvider)
        {
            _tagProvider = tagProvider ?? throw new ArgumentNullException(nameof(tagProvider));
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                return;
            }
            var uri = GetActionName(context.ActionDescriptor);
            var currentEtag = _tagProvider.GetETag(uri);
            if (!string.IsNullOrEmpty(currentEtag))
            {
                context.HttpContext.Response.Headers.Add("ETag", currentEtag);
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var uri = GetActionName(context.ActionDescriptor);
            var requestedEtag = context.HttpContext.Request.Headers["If-None-Match"];
            var currentEtag = _tagProvider.GetETag(uri);
            if (requestedEtag.Contains(currentEtag))
            {
                context.HttpContext.Response.Headers.Add("ETag", currentEtag);
                context.Result = new StatusCodeResult(StatusCodes.Status304NotModified);
            }
        }
        private string GetActionName(ActionDescriptor actionDescriptor)
        {
            return $"{actionDescriptor.RouteValues["controller"]}.{actionDescriptor.RouteValues["action"]}";
        }
    }
