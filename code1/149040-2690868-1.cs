    public Type ControllerType(string controllerName)
    {
       var fullName = controllerName + "Controller";
       var assemblyName = Assembly.GetExecutingAssembly().FullName;
       return Activator.CreateInstance(assemblyName, fullTypeName).GetType();
    }
    
    public MethodInfo ActionMethodInfo(string actionName, Type controllerType)
    {
       return controllerType.GetMethod(actionName);
    }
