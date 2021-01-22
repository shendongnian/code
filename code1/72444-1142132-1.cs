    List<Type> genTypes = new List<Type>();
    foreach(Type intType in t.GetInterfaces()) {
        if(intType.IsGenericType && intType.GetGenericTypeDefinition()
            == typeof(IGeneric<>)) {
            genTypes.Add(intType.GetGenericArguments()[0]);
        }
    }
    // now look at genTypes
