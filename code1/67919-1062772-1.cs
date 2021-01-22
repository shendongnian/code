    System.Type myInterface = typeof(MaLio.IMyInterface);
    // show that we really are dealing with an interface 
    if (myInterface.IsInterface) {
       System.Reflection.MethodInfo staticMethod = myInterface.GetMethod("DoStaticWork");
       staticMethod.Invoke(null, null);
    }
