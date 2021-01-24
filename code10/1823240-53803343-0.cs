    public class AreaRouter : MvcRouteHandler, IRouter
    {
        public new async Task RouteAsync(RouteContext context)
        {
            string url = context.HttpContext.Request.Headers["HOST"];
 
            string firstDomain = url.Split('.')[0];
            string subDomain = char.ToUpper(firstDomain[0]) + firstDomain.Substring(1);
 
            string area = subDomain;
 
            context.RouteData.Values.Add("area", subDomain);
 
            await base.RouteAsync(context);
        }
    }
