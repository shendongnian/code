    Guid webId = Guid.Empty;
    SPSecurity.RunWithElevatedPrivileges(delegate() // it's required?
    {
        using (SPSite site = new SPSite(SPContext.Current.Site.ID))
        {
            try
            {
                site.AllowUnsafeUpdates = true;
                using(SPWeb web = site.AllWebs.Add(RelativeITTURL, projectCode, 
                    SiteDescription, LocaleID, siteDefinitionTemplate, false, false))
                {
                    web.AllowUnsafeUpdates = true;
                    web.Navigation.UseShared = true;
                    web.BreakRoleInheritance(true);
                    web.AllowUnsafeUpdates = true;
                    web.Update();
                    webId = new Guid(NewWeb3.ID.ToString());
                }
            }
            catch (Exception ex3)
            {
                // error handler
            }
        }
     });
