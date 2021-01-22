    var returnResult = 
        typeof(MetaDataUtil)
        .GetMethods().Single( m=> m.Name == "GetColumnsAsGrid" && m.IsGenericMethod 
            && m.GetParameters().Count() == 0 //the overload that takes 0 parameters i.e. SomeMethod()
            && m.GetGenericArguments().Count() == 1 //the overload like SomeMethod<OnlyOneGenericParam>()
        )
        .MakeGenericMethod(new [] { genericTypeParameter })
        .Invoke(someInstance, null);
