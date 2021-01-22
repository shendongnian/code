For example, this module rewrites the path on BeginRequest and then sets it back to the original value on EndRequest. When this module is used the original path appears in the IIS log file:
    public class RewriteModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }
        static void OnBeginRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            app.Context.Items["OriginalPath"] = app.Context.Request.Path;
            app.Context.RewritePath("Default.aspx?id=1");
        }
        static void OnEndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var originalPath = app.Context.Items["OriginalPath"] as string;
            if (originalPath != null)
            {
                app.Context.RewritePath(originalPath);
            }
        }
        public void Dispose()
        {
        }
    }
