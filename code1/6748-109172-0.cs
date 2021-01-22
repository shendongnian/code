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
            var app = (HttpApplication)sender;
    
            if (IsMissing(app.Context))
                app.Context.Handler = PageParser.GetCompiledPageInstance(
                    "~/404.aspx", app.Server.MapPath("~/404.aspx"), app.Context);
        }
    
        bool IsMissing(HttpContext contect)
        {
            return false;
        }
    }
