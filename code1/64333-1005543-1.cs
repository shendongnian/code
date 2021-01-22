    static void Main() {
        Dictionary<string, object> propertyBag =
            new Dictionary<string, object>();
        // these are the values from your xml
        propertyBag["Left"] = 1;
        propertyBag["Top"] = 2;
        propertyBag["Right"] = 3;
        propertyBag["Bottom"] = 4;
        // the type to create
        Type type = typeof(Padding);
        object obj = CreateObject(type, propertyBag);
        
    }
    static object CreateObject(Type type, IDictionary<string,object> propertyBag)
    {
        ConstructorInfo[] ctors = type.GetConstructors();
        // clone the property bag and make it case insensitive
        propertyBag = new Dictionary<string, object>(
            propertyBag, StringComparer.OrdinalIgnoreCase);
        ConstructorInfo bestCtor = null;
        ParameterInfo[] bestParams = null;
        for (int i = 0; i < ctors.Length; i++)
        {
            ParameterInfo[] ctorParams = ctors[i].GetParameters();
            if (bestCtor == null || ctorParams.Length > bestParams.Length)
            {
                bestCtor = ctors[i];
                bestParams = ctorParams;
            }
        }
        if (bestCtor == null) throw new InvalidOperationException(
             "Cannot create - no constructor");
        object[] args = new object[bestParams.Length];
        for (int i = 0; i < bestParams.Length; i++)
        {
            args[i] = propertyBag[bestParams[i].Name];
            propertyBag.Remove(bestParams[i].Name);
        }
        object obj = bestCtor.Invoke(args);
        // TODO: if we wanted, we could apply any unused keys in propertyBag
        // at this point via properties
        return obj;
    }
