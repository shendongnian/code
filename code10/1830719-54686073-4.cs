    Microsoft.Owin.Security.IAuthenticationManager authManager = Request.GetOwinContext().Authentication;
    System.Security.Claims.ClaimsPrincipal authUser = authManager.User;
    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    var user = manager.FindById(authUser.Identity.GetUserId<long>());
    MenuSiteMap.Provider = SiteMap.Providers[user == null ? "MenuSiteMapProvider" : "MemberSiteMapProvider"];
