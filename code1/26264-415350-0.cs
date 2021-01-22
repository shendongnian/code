    using (SPWeb spWeb = SPControl.GetContextSite(HttpContext.Current).OpenWeb())
    {
        SpUser spUser = null;
        if (spWeb != null)
        {
            spUser = spWeb.SiteUsers[@"foo\bar"];
        }
    }
