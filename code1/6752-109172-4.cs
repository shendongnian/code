    using System.Web;
    using System.Web.UI;
    
    class Smart404Module : IHttpModule
    {
        public void Dispose() {}
    
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new System.EventHandler(DoMapping);
        }
    
        void DoMapping(object sender, System.EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
    
            if (IsMissing(app.Context))
                app.Context.Handler = PageParser.GetCompiledPageInstance(
                    "~/404.aspx", app.Request.MapPath("~/404.aspx"), app.Context);
        }
    
        bool IsMissing(HttpContext context)
        {
            string path = context.Request.MapPath(context.Request.Url.AbsolutePath);
    
            if (System.IO.File.Exists(path) || (System.IO.Directory.Exists(path)
                && System.IO.File.Exists(System.IO.Path.Combine(path, "default.aspx"))))
                return true;
            return false;
        }
    }
