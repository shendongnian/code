    var typeOfClass = typeof(ClassWithGenericStaticMethod);
    MethodInfo methodInfo = typeOfClass.GetMethod("DoSomething",   
        System.Reflection.BindingFlags.Static | BindingFlags.Public);
    MethodInfo genericMethodInfo = 
        methodInfo.MakeGenericMethod(new Type[] { typeOfGeneric });
    genericMethodInfo.Invoke(null, new object[] { "hello" });
