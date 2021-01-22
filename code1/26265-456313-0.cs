    SPSite contextSite = SPControl.GetContextSite(HttpContext.Current);
    using (SPWeb spWeb = contextSite.OpenWeb())
    {
      SPUser spUser = spWeb.SiteUsers[@"foo\bar"];
      // Process spUser
    }
    // DO NOT use spUser
    // DO NOT dispose site from HttpContext
