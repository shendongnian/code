    String typeToLoad = "Master.Enterprise"; // this can be from a config or database call
    Type objType = asm.GetType(typeToLoad, true);
    
    if (!objType.IsPublic)
    return null;
    
    // make sure the type isn't Abstract
    if (((objType.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract))
        return null;
    
    // IEnterprise is the interface that all of the plugin types must implement to be loaded
    Type objInterface = objType.GetInterface("IEnterprise", true);
    
    if (objInterface == null)
        return null;
    
        var iri = (IEnterprise)Activator.CreateInstance(objType);
        return iri;
    
        
        
