    public partial class SiteBasic : System.Web.UI.MasterPage
    {
        public string ResolveURL(string url)
        { 
            var resolvedURL=this.Page.ResolveClientUrl(url);
            return resolvedURL;
        }
        public string cssLink(string cssURL)
        {
            return string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>", 
                        ResolveURL(cssURL));
        }
        public string jsLink(string jsURL)
        {
            return string.Format("<script src='{0}' type='text/javascript'></script>", 
                        ResolveURL(jsURL));
        }
    }
