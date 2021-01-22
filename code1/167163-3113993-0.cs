    private void Application_Start(object sender, EventArgs e)
    {
        SiteMap.SiteMapResolve += ResolveCustomNodes;
    }
    private SiteMapNode ResolveCustomNodes(object sender, SiteMapResolveEventArgs e)
    {
        // catch ~/Image.aspx and ~/Headline.aspx
        if (e.Context.Request.AppRelativeCurrentExecutionFilePath.Equals(
            "~/Image.aspx", StringComparison.OrdinalIgnoreCase)
          || e.Context.Request.AppRelativeCurrentExecutionFilePath.Equals(
            "~/Headline.aspx", StringComparison.OrdinalIgnoreCase))
        {
            string location = context.Request.QueryString["location"];
            if (location != null) // ignore everything except location=
                return e.Provider.FindSiteMapNode(
                    e.Context.Request.AppRelativeCurrentExecutionFilePath
                    "?location=" + HttpUtility.UrlEncode(location));
        }
        return null; // use default implementation;
    }
