    public class RedirectAzureWebsitesRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            HostString host = context.HttpContext.Request.Host;
            if (host.HasValue && host.Value.ToLower().Contains(".azurewebsites.net"))
            {
                //if we are viewing on azure's domain - skip the www redirect
                context.Result = RuleResult.SkipRemainingRules;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
            }
        }
    }
