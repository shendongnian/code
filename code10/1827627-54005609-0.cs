    private static readonly IDictionary<string, Type> AttributeMap
         = new Dictionary<string, Type>
         {
             { "GET", typeof(HttpGetAttribute) },
             { "DELETE", typeof(HttpDeleteAttribute) },
             { "PUT", typeof(HttpPutAttribute) },
         };
    public string ResolveForSeeOtherResult(IUrlHelper urlHelper, object resource, object routeValues = null)
    {
        string scheme = urlHelper.ActionContext.HttpContext.Request.Scheme;
        var httpAttribute = AttributeMap[urlHelper.ActionContext.HttpContext.Request.Method];
        var resourceControllerTypes = resource.GetType().Assembly.GetTypes()
                .Where(type => type.IsDefined(typeof(ResourceControllerAttribute), false));
        foreach (var type in resourceControllerTypes)
        {
            var resourceControllerAttribute = type.GetCustomAttributes(false).OfType<ResourceControllerAttribute>().Single();
            if (resourceControllerAttribute.Value == resource.GetType())
            {
                var methodInfo = type.GetMethods().Where(x => x.IsDefined(httpAttribute, false)).Single();
                var result = urlHelper.Action(methodInfo.Name, resourceControllerAttribute.ControllerName, routeValues, scheme);
                return result;
             }
        }
        var errorMessage = string.Format(ErrorMessages.UnrecognisedResourceType, resource.GetType());
        throw new InvalidOperationException(errorMessage);
    }
