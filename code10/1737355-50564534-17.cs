    var specificationParameter = actionContextAccessor.ActionContext.ActionDescriptor.Parameters.SingleOrDefault(p => p.ParameterType == typeof(ISpecification<>));
    if (specificationParameter != null)
    {
       // add pagination links or whatever
       var urlHelper = new UrlHelper(actionContextAccessor.ActionContext);
       var link = urlHelper.Action(new UrlActionContext()
       {
           Protocol = httpContext.Request.Scheme,
           Host = httpContext.Request.Host.ToUriComponent(),
           Values = yourspecification
       })
    }
