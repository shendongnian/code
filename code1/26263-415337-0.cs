    // Get the site.
    var contextSite = SPControl.GetContextSite(HttpContext.Current);
    
    // Work with the web.
    using (SPWeb web = contextSite.OpenWeb())
    {
      // Get the user and work with it.
      SPUser spUser = web.SiteUsers[@"foo\bar"];
    }
