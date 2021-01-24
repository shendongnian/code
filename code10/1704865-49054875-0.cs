     public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "<ids address>",
                ValidationMode = ValidationMode.Both,
                RequiredScopes = new[] { "myapi" }
            });
            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
			app.UseWebApi(config);
        }
