    public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations) {
    
        var controllerActionContext = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
        if(controllerActionContext != null) {
            var controllerTypeInfo = controllerActionContext.ControllerTypeInfo;
            
            //From the type info you should be able to get the assembly
            var controllerAssemblyName = controllerTypeInfo.AsType().Assembly.FullName.ToString();
        }
     
        //...
    }
