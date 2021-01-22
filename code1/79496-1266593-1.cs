    using (SPWeb oWebsite = SPContext.Current.Site.OpenWeb("Website_URL"))
    {
        SPGroupCollection collGroups = oWebsite.Groups;
        foreach (SPGroup oGroup in collGroups)
        {
            foreach(SPUser oUser in oGroup.Users)
            {
               Response.Write(oUser.Name);
            }
        }
    }
