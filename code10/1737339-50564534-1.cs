    var specificationParameter = actionContextAccessor.ActionContext.ActionDescriptor.Parameters.SingleOrDefault(p => p.ParameterType == typeof(ISpecification<>));
    if (specificationParameter != null)
    {
       // add pagination links or whatever
    }
