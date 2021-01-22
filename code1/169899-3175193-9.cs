    Type typeToTest = GetTypeFromSomewhere();
    string ns = typeToTest.Namespace;
    byte[] pk = typeToTest.Assembly.GetName().GetPublicKeyToken();
    byte[] pkSys = typeof(int).Assembly.GetName().GetPublicKeyToken();
    if (((ns == "System") || (ns.StartsWith("System.")) && pk.SequenceEqual(pkSys))
        SystemTypeAction();
    else
        NotSystemType();
