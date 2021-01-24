    public static void SetSharingCapability(string fullWebUrl, ClientContext context)
    {
            Tenant tenant = new Tenant(context);
            SiteProperties siteProp = tenant.GetSitePropertiesByUrl(fullWebUrl, true);
                        
            siteProp.SharingCapability = SharingCapabilities.Disabled;
            siteProp.Update();
            context.ExecuteQuery();
            siteProp = tenant.GetSitePropertiesByUrl(fullWebUrl, true);
            context.Load(siteProp, p => p.Status);
            context.ExecuteQuery();
            while (siteProp.Status == "Updating")
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                siteProp = tenant.GetSitePropertiesByUrl(fullWebUrl, true);
                context.Load(siteProp);
                context.ExecuteQuery();
            }
     }
