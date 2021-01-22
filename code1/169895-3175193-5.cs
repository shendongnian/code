    Type typeToTest = GetTypeFromSomewhere();
    string namespace = typeToTest.Namespace;
    if ((namespace == "System") || namespace.StartsWith("System."))
        SystemTypeAction();
    else
        NotSystemTypeAction();
