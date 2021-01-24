    void Application_BeginRequest(object sender, EventArgs e) {
        if (SiteRoot == null) {
            SiteRoot = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                (VirtualPathUtility.ToAbsolute("~") == "/" ? "" : VirtualPathUtility.ToAbsolute("~"));
        }
    }
