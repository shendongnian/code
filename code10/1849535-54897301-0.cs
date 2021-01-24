    // Get the method we want to call.
    MethodInfo inOrderTreeWalkMethod = set.GetType().GetMethod(
        "InOrderTreeWalk", BindingFlags.NonPublic | BindingFlags.Instance);
    // Get the internal delegate type from the parameter info.  The type retrieved here
    // is already close-constructed so we don't have to do any generic-related manipulation.
    Type treeWalkPredicateType = inOrderTreeWalkMethod.GetParameters()[0].ParameterType;
    // Get the method we want to be called for each node.
    MethodInfo myPredicateMethod = GetType().GetMethod(
        nameof(MyPredicate), BindingFlags.NonPublic | BindingFlags.Instance);
    // Create the delegate.  This is where the magic happens.  The runtime validates
    // type compatibility and throws an exception if something's wrong.
    Delegate myPredicateDelegate = myPredicateMethod.CreateDelegate(treeWalkPredicateType, this);
    // Call the internal method and pass our delegate.
    bool result = (bool)inOrderTreeWalkMethod.Invoke(set, new object[] { myPredicateDelegate });
