    var stringVal="6e3ba183-89d9-e611-80c2-00155dcfb231"; // guid value as string to set
    var prop = obj.GetType().GetProperty("FooGuidProperty"); // property to be setted
    var propType = prop.PropertyType;
    
    // var will be type of guid here
    var valWithRealType = TypeDescriptor.GetConverter(propType).ConvertFrom(stringVal); 
