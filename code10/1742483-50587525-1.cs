    var assemblyLoaded = Assembly.LoadFile(absolutePath);
    var type = assemblyLoaded.GetType("CreateContactPlugin.Plugin");
    
    var instance = Activator.CreateInstance(type) as IContactPlugin;
    
    if (instance == null)
    {
        //That type wasn't an IContactPlugin, do something here...
    }
    instance.Execute("name of contact");
