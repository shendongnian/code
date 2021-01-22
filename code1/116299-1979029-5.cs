    var initializers = from type in assembly.GetTypes()
                       let initializer = type.TypeInitializer
                       where initializer != null &&
                             type.GetCustomAttributes(typeof(..., false).Length > 0
                       select initializer;
    foreach (ConstructorInfo initializer in initializers)
    {
        initializer.Invoke(null, null);
    }
