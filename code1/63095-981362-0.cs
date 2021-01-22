    Type type = CustomGetTypeMethod();
    var obj = Activator.CreateInstance(type);
    
    ...
    
    
    if(obj is MyCustomType)
    {
        ((MyCustomType)obj).Property1;
    }
    else if (obj is MyOtherCustomType)
    {
        ((MyOtherCustomType)obj).Property2;
    }
