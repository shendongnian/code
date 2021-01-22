    protected override IKernel CreateKernel()
    {
        // The name of the class, e.g. retrieved from a config
        string moduleName = "MyApp.MyAppTestNinjectModule";
    
        // Type.GetType takes a string and tries to find a Type with
        // the *fully qualified name* - which includes the Namespace
        // and possibly also the Assembly if it's in another assembly
        Type moduleType = Type.GetType(moduleName);
    
        // If Type.GetType can't find the type, it returns Null
        NinjectModule module;
        if (moduleType != null)
        {
            // Activator.CreateInstance calls the parameterless constructor
            // of the given Type to create an instace. As this returns object
            // you need to cast it to the desired type, NinjectModule
            module = Activator.CreateInstance(moduleType) as NinjectModule;
        }
        else
        {
            // If the Type was not found, you need to handle that. You could instead
            // initialize Module through some default type, for example
            // module = new MyAppDefaultNinjectModule();
            // or error out - whatever suits your needs
            throw new MyAppConfigException(
                 string.Format("Could not find Type: '{0}'", moduleName),
                 "injectModule");
        }
    
        // As module is an instance of a NinjectModule (or derived) class, we
        // can use it to create Ninject's StandardKernel
        return new StandardKernel(module);
    }
