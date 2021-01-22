    class HtmlHelper
    {
        public static void IncludeScript(Page page, String key, String location)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered(key))
                 page.ClientScript.RegisterClientScriptInclude(key, location);
        }
        
        public static void IncludeCSS(Page page, String src)
        {
            HtmlLink css = new HtmlLink();
            css.Href = src;
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            css.Attributes["media"] = "all";
        
            page.Header.Controls.Add(css);
        }
    }
