    MethodInfo getCountMethod = myObj.GetMethod(
        "GetCount", 
        BindingFlags.Public | BindingFlags.Instance | ...); // Fill the right flags
    var types = GetTypesWithHasPrimaryImageAttribute();
    Func<Entity, bool> predicate = x => x.PrimaryImageId == id;
    foreach(Type t in types)
    {
         getCountMethod.MakeGenericMethod(type).Invoke(myObj, predicate);
    }
