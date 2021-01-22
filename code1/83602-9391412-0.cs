    using (SPSite oSiteCollection = new SPSite(SPContext.Current.Site.Url))
    {
        using (SPWeb oWeb = oSiteCollection.OpenWeb(SPContext.Current.Web))
        {
            SPList oList = oWeb.Lists["Announcements"];
            // You may also use 
            // SPList oList = oWeb.GetList("/Lists/Announcements");
            // to avoid querying all of the sites' lists
            SPListItem oListItem = oList.Items.Add();
            oListItem["Title"] = "My Item";
            oListItem["Created"] = new DateTime(2004, 1, 23);
            oListItem["Modified"] = new DateTime(2005, 10, 1);
            oListItem["Author"] = 3;
            oListItem["Editor"] = 3;
            oListItem.Update();
        }
    }
