    public static void Register(HttpConfiguration config) {
        var constraintResolver = new DefaultInlineConstraintResolver() {
            ConstraintMap = {["apiVersion"] = typeof(ApiVersionRouteConstraint)}
        };
        var directRouteProvider = new WebApiCustomDirectRouteProvider();
        // Attribute routing. (with inheritance)
        config.MapHttpAttributeRoutes(constraintResolver, directRouteProvider);
        config.AddApiVersioning(_ => { _.AssumeDefaultVersionWhenUnspecified = true; });
    }
    
