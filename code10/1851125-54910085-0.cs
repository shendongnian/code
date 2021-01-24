    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
        public async override Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            } catch(Exception e)
            {
                Logger.Error($"Encountered error in authenticating {e.ToString()}");
                if(e.Source.Equals("Microsoft.IdentityModel.Protocols"))
                {
                    context.Response.Redirect("/Home/OwinError");
                } else
                {
                    throw e;
                }
            }
        }
    }
