    Type theType = typeof(ActiveInstance.ActiveInstanceBase);
    foreach(Type type in assembly.GetTypes())
    {
        if (type.IsSubclassOf(theType))
        { ... }
    }
