    private static void AuthenticateRequestHandler(object sender, EventArgs e)
    {
        HttpApplication app = sender as HttpApplication;
        if(app == null) return;
        Uri url = app.Request.Url;
        string domain = url.Host;
        string path = url.AbsolutePath.ToLower().Replace("default.aspx", "");
        IInjectionWrapper wrapper = new WindsorWrapper();
        ISiteProvider provider = wrapper.Resolve<ISiteProvider>();
        Site site = provider.FindSiteByDomain(domain);
        if (site == null)
            return;
        ActiveContext.Current.Site = site;
    }
