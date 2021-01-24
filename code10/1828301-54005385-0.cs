    private void Method()
    {
        using (SPSite oSiteCollection = new SPSite(currentUrl))
        {
            using (SPWeb oWebsite = oSiteCollection.OpenWeb())
            {
            }
        }
    });
    SPSecurity.RunWithElevatedPrivileges(Method);
