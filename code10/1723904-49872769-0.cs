    public class AuthTokenHeaderParameter : IOperationFilter
    {		
    	public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
    	{
    		if (operation.parameters == null)
    			operation.parameters = new List<Parameter>();
    
    		var authorizeAttributes = apiDescription
    			.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>();
    
    		if (authorizeAttributes.ToList().Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute)) == false)
    		{
    			operation.parameters.Add(new Parameter()
    			{
    				name = "ApiKey",
    				@in = "header",
    				type = "string",
    				description = "Authorization Token. Please remember the Bearer part",
    				@default = "Bearer ",
    				required = true
    			});
    			operation.parameters.Add(new Parameter()
    			{
    				name = "AppId",
    				@in = "header",
    				type = "string",
    				description = "AppId",
    				required = true
    			});
    		}
    	}
    }
