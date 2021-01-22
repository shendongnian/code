    using (SPSite site = new SPSite("http://sharepoint"))
    {
        using (SPWeb web = site.RootWeb)
        {
            SPList list = web.Lists["My List"];
            SPListItem listItem = list.AddItem();
            listItem["Title"] = "The Title";
            listItem["CustomColumn"] = "I am custom";
            listItem.Update();
         }
    }
