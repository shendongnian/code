     // use Authentication from IdentityServer4
     app.UseAuthentication();
     // Serve static files
     app.UseDefaultFiles();
     app.UseStaticFiles(new StaticFileOptions()
     {
         ContentTypeProvider = ContentTypeProviderFactory.GetContentTypeProvider()
     });
            
     app.UseMiddlewareFrom<AuthSchemeMiddleware>(container);
     app.UseMvcWithDefaultRoute();
