    using System.Reflection;
   
    // If the constructor takes arguments, otherwise pass these as null
    Type[] pTypes = new Type[1];
    pTypes[0] = typeof(object);    
    object[] argList = new object[1];
    argList[0] = constructorArgs;
    
    ConstructorInfo c = typeof(Foo).GetConstructor
        (BindingFlags.NonPublic |
         BindingFlags.Instance,
         null,
         pTypes,
         null);
    
    Foo foo = 
        (Foo) c.Invoke(BindingFlags.NonPublic,
                       null, 
                       argList, 
                       Application.CurrentCulture);
