public class myHandler : IHttpHandler, IRouteHandler
{
    public bool IsReusable
    {
        get { return true; }
    }
    public void ProcessRequest(HttpContext context)
    {
        // your processing here
    }
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return this;
    }
}
 
