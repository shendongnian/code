    this.DisableEventFiring();
    try
    {
      using (SPSite site = new SPSite(siteId, properties.Site.SystemAccount.UserToken) {
    
      }
    }
    finally
    {
    this.EnableEventFiring();
    }
