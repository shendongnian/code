    public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations) {
    
        var controllerActionDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
        if(controllerActionDescriptor != null) {
            var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;            
            //From the type info you should be able to get the assembly
            var controllerAssemblyName = controllerTypeInfo.AsType().Assembly.FullName.ToString();
        }
     
        //...
    }
