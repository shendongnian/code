    private string CreateSiteCollection(string hostWebUrl, string url, string template, string title, string adminAccount)
    {
        // Resolve root site collection URL from host web. We assume that this has been set as the "TenantAdminSite"
        string rootSiteUrl = hostWebUrl.Substring(0, 8 + hostWebUrl.Substring(8).IndexOf("/"));
    
        //Resolve URL for the new site collection
        var webUrl = string.Format("{0}/sites/{1}", rootSiteUrl, url);
    
        // Notice that this assumes that AdministrationSiteType as been set as TenantAdministration for root site collection
        // If this tenant admin URI is pointing to site collection whihc is host named site collection, code does create host named site collection as well
        var tenantAdminUri = new Uri(rootSiteUrl);
        string realm = TokenHelper.GetRealmFromTargetUrl(tenantAdminUri);
        var token = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, tenantAdminUri.Authority, realm).AccessToken;
        using (var adminContext = TokenHelper.GetClientContextWithAccessToken(tenantAdminUri.ToString(), token))
        {
            var tenant = new Tenant(adminContext);
            var properties = new SiteCreationProperties()
            {
                Url = webUrl,
                Owner = adminAccount,
                Title = title,
                Template = template
            };
    
            //start the SPO operation to create the site
            SpoOperation op = tenant.CreateSite(properties);
            adminContext.Load(op, i => i.IsComplete);
            adminContext.ExecuteQuery();
        }
        return webUrl;
    }
