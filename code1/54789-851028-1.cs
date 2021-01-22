    SPSite oSiteCollection = SPContext.Current.Site;
    using(SPWeb oWebsite = oSiteCollection.AllWebs["Site_Name"])
    {
        SPMember oMember = oWebsite.Roles["Role_Name"];
        oWebsite.Permissions[oMember].PermissionMask = 
            SPRights.ManageLists | SPRights.ManageListPermissions;
    }
