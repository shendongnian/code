    string controllerAssemblyName = null;
    
    var controllerActionDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
    if (controllerActionDescriptor != null)
    {
        var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
        controllerAssemblyName = controllerTypeInfo.AsType().Assembly.FullName;
    }
    else
    {
        var controllerContext = new ControllerContext(context.ActionContext);
        var factory = CreateControllerFactory();
        var controller = factory.CreateController(controllerContext);
        controllerAssemblyName = controller.GetType().Assembly.FullName;
    }
    
    
    private static DefaultControllerFactory CreateControllerFactory()
    {
        var propertyActivators = new IControllerPropertyActivator[]
        {
            new DefaultControllerPropertyActivator(),
        };
    
        return new DefaultControllerFactory(
            new DefaultControllerActivator(new TypeActivatorCache()), 
            propertyActivators);
    }
