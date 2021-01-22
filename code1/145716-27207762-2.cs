    using (var site = new SPSite(siteUrl))
    {
        using (var web = site.OpenWeb())
        {
            var subWeb = web.Webs["Announcements"];
            var publishingWeb = PublishingWeb.GetPublishingWeb(web);
            publishingWeb.Navigation.ExcludeFromNavigation(false,subWeb.ID);
            publishingWeb.Update();
        }
    }
