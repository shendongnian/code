    Type clazz = System.Reflection.Assembly.GetExecutingAssembly().GetType("MyClass");
    
    System.Reflection.ConstructorInfo ci = clazz.GetConstructor(new Type[] { });
    object instance = ci.Invoke(null); /* Send parameters instead of null here */
    
    System.Reflection.MethodInfo mi = clazz.GetMethod("MyMethod");
    mi.Invoke(instance, null); /* Send parameters instead of null here */
