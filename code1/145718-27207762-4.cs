     using (var ctx = new ClientContext(webUri))
     {
         //Get sub site
         var result = ctx.LoadQuery(ctx.Web.Webs.Where(w => w.Title == "Archive"));
         ctx.ExecuteQuery();
         var subWeb = result.FirstOrDefault();
         //Hide web from Global navigation
         var navigation = new ClientPortalNavigation(ctx.Web);
         navigation.ExcludeFromNavigation(true, subWeb.Id);
         navigation.SaveChanges();
     }
