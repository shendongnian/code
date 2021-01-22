    System.Web.HttpCookie authcookie = System.Web.Security.FormsAuthentication.GetAuthCookie(UserName, False);
    authcookie.Domain = "parent.com";
    HttpResponse.AppendCookie(authcookie);
    HttpResponse.Redirect(System.Web.Security.FormsAuthentication.GetRedirectUrl(UserName, 
                                                                           False));
