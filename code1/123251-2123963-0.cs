    public class SeoModule : IHttpModule
    {
        public void Dispose()
        { }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }
        private void OnBeginRequest(object source, EventArgs e)
        {
            var application = (HttpApplication)source;
            HttpContext context = application.Context;
            if (context.Request.Url.Query.ToLower().Contains("action=")) {
                context.RewritePath(context.Request.Url.ToString().Replace("action=", "actionx="));
            }
        }
    }
