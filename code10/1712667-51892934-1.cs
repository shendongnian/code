     if (User.Identity.IsAuthenticated)
                {
                    var ssotype = WebConfigurationManager.AppSettings["SSOType"];
                    if (!string.IsNullOrEmpty(ssotype) && ssotype == "onelogin")
    {
                        var email = System.Security.Claims.ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type.Equals("User.email")).Value;
                        Session["loginUserId"] = email;
                    }
                    else
                    {
                        var email = System.Security.Claims.ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")).Value;
                        Session["loginUserId"] = email;
                    }
                    Response.Redirect("index.html",false);
                }
                else
                {
                    String redirecturl = null;
                    var idp = Sustainsys.Saml2.Configuration.SustainsysSaml2Section.Current.IdentityProviders.FirstOrDefault();
                    var routevalues = new RouteValueDictionary();
                    routevalues.Add("idp", idp.EntityId);
                    redirecturl = "~/Saml2/SignIn?idp=" + HttpUtility.UrlEncode(idp.EntityId);
                    Response.Redirect(redirecturl,false);
                    
    }
      
