    // Define the generic type.
    var generic = typeof(Test123<>);
    
    // Specify the type used by the generic type.
    var specific = generic.MakeGenericType(new Type[] { typeof(int)});
    
    // Create the final type (Test123<int>)
    var instance = Activator.CreateInstance(specific, true);
