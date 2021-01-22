    class myClass
    {
    }
    
    myClass instance = new myClass();
    
    Type t = instance.GetType;
    
    //top is just to show obtaining a type...
    
    Type listType = typeof(List<>);
    var listOfType = listType.MakeGenericType(t);
    
    var listOfMyClassInstance = Activator.CreateInstance(listOfType);
