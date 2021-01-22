    Type genericType = typeof(Repository<>);
    Type[] typeArgs = { Type.GetType("TypeRepository") };
    Type repositoryType = genericType.MakeGenericType(typeArgs);
    
    object repository = Activator.CreateInstance(repositoryType);
