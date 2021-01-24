       public class RewriteRules
    {
        public static void RedirectRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            if (request.Path.Value.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                context.HttpContext.Response.Redirect("/Home.html");
            }
            else if(!request.Path.Value.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
            {
                context.HttpContext.Response.Redirect($"{ request.Path.Value }.html");
            }
        }
        public static void ReWriteRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;            
            if (request.Path.Value.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
            {
                context.HttpContext.Request.Path = context.HttpContext.Request.Path.Value.Replace(".html","");
              
            }
        }
    }
