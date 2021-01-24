    Do you need ASP.NET core application or just expose REST endpoints ? I am thinking you are trying to use it for the benefits of the library. If latter is true,   
     I have done a similar thing where we have exposed some REST endpoints hosted in our legacy Windows service through "Microsoft.Owin.Hosting". This looks exactly like the ASP.NET WEPAPI
        
        1) In your windows service, you can start the WebApp like
        
               //WEBAPI URL
               private const string WEBAPI_BASEADDRESS = "https://+:{port number}/";
               // declare a Idisposable variable
               private IDisposable webAPI;
               //Use Microsoft Owin's library to start it up
               webAPI = WebApp.Start<Startup>(url: WEBAPI_BASEADDRESS);
        
        //above "Startup" is a class you would declare in your other class library (see below number 2)
        
        
        2) You can create a new C# class library with a class named "Startup"  and use the system.Web.Http "Httpconfiguration" class as below
        
        /// <summary>
        /// Web API startup method
        /// </summary>
        public class Startup
        {
            private const string TOKEN_URL = "/api/token";
            private const string BASE_URL = "/api/{controller}/{id}";
            // This code configures Web API. The Startup class is specified as a type
            // parameter in the WebApp.Start method.
            public void Configuration(IAppBuilder appBuilder)
            {
        
                // Configure Web API for self-host. 
                HttpConfiguration config = new HttpConfiguration();
                config.SuppressDefaultHostAuthentication();
                config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: BASE_URL,
                    defaults: new { id = RouteParameter.Optional }
                );
        
                appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString(TOKEN_URL),
                    Provider = new CustomAuthorizationServerProvider()
                });
                appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        
                //Swagger support
                SwaggerConfig.Register(config);
                //appBuilder.UseCors(CorsOptions.AllowAll);
                appBuilder.UseWebApi(config);
            }
        }
        
        3) Above code has a CustomAuthorizationProvider where you can declare your own Custom OAuth Authorization and do any kind of authentication you want as below
        
            public class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
        
        and override the "`public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)`"
    
    4) Then you can just spin up WebAPI controllers
        [Authorize]
        public class XXXController : ApiController
        {
    }
        
    Hope this helps . Let me know if something is not clear.
