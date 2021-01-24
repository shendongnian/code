    public class RedirectAzureWebsitesRule : IRule
    {
        public int StatusCode { get; } = (int)HttpStatusCode.MovedPermanently;
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            HostString host = context.HttpContext.Request.Host;
            if (host.HasValue && host.Value == "my-project.azurewebsites.net")
            {
                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = StatusCode;
                response.Headers[HeaderNames.Location] = request.Scheme + "://" + "www.example.com" + request.PathBase + request.Path + request.QueryString;
                context.Result = RuleResult.EndResponse;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
            }
        }
    }
