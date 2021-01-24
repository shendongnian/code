    string typeName = "System.String";
    Type typeArg = Type.GetType(typeName);
    
    Type genericClass = typeof(List<>);
    Type newClass = genericClass.MakeGenericType(typeArg);
    
    object created = Activator.CreateInstance(newClass);
