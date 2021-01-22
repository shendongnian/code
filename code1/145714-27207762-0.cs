    using (var ctx = new ClientContext(webUri))
    {
            
         //Get page file
         var pageFile = ctx.Web.GetFileByServerRelativeUrl("/news/Pages/Announcements.aspx");
         ctx.Load(pageFile);
         ctx.ExecuteQuery();
         //Hide page from Global navigation
         var navigation = new ClientPortalNavigation(ctx.Web);
         navigation.ExcludeFromNavigation(true, pageFile.UniqueId);
         navigation.SaveChanges();
     }
