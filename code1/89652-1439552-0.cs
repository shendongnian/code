    Assembly a = Assembly.LoadFrom("pathToDll");
    Type interfaceType = typeof(Interfaces.ILogger);
    Type implementingType = a.GetTypes.Where(t => t.IsAssignableTo(interfaceType)).First();	//add any other constraints to decide mapping
    
    container.RegisterType(interfaceType, implementingType);
