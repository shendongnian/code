    Type typeToTest = GetTypeFromSomewhere();
    if (typeToTest.Namespace.StartsWith("System"))
        SystemTypeAction();
    else
        NotSystemTypeAction();
