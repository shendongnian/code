    using System;
    using System.Web;
    using System.Web.Security;
    
    namespace TempWebApp.Classes {
      public class CheckingAuthenticate : IHttpModule {
        public void Dispose() {
            //clean-up code here.
        }
        public void Init(HttpApplication context) {
          context.PostAuthenticateRequest += OnPostAuthenticate;
        }
        public void OnPostAuthenticate(object sender, EventArgs e) {
          var app = sender as HttpApplication;
          if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(app.Request.Path,
                                                                app.User,
                                                                "GET")){
            //Code here to read cookies, redirect user etc.
          }
        }
      }
    }
