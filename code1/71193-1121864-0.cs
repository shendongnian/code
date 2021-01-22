    // this conditional is necessary if myType can be an interface,
    // because an interface doesn't implement itself: for example,
    // typeof (IList<int>).GetInterfaces () does not contain IList<int>!
    if (myType.IsInterface && myType.IsGenericType && 
        myType.GetGenericTypeDefinition () == typeof (IList<>))
        return myType.GetGenericArguments ()[0] ;
    foreach (var i in myType.GetInterfaces ())
        if (i.IsGenericType && i.GetGenericTypeDefinition () == typeof (IList<>))
            return i.GetGenericArguments ()[0] ;
