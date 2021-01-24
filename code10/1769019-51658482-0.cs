        public void Configuration( IAppBuilder builder )
        {
            // we only need to change the default constraint resolver for services that want urls with versioning like: ~/v{version}/{controller}
            var constraintResolver = new DefaultInlineConstraintResolver() { ConstraintMap = { ["apiVersion"] = typeof( ApiVersionRouteConstraint ) } };
            var configuration = new HttpConfiguration();
            var httpServer = new HttpServer( configuration );
            // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
            configuration.AddApiVersioning( o => o.ReportApiVersions = true );
            configuration.MapHttpAttributeRoutes( constraintResolver );
            builder.UseWebApi( httpServer );
        }
