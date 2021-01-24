    //LOAD MSCORLIB.DLL ASSEMBLY
    var assembly = Assembly.Load("mscorlib.dll");
    //GET MSCORLIB.DLL TYPES
    Type[] types = assembly.GetTypes();
    foreach (string error in errorList)
        foreach (Type type in types)
        if (type.Name == error)
        {
            System.Console.WriteLine("using " + type.FullName.Substring(0, type.FullName.Length - (error.Length + 1)) + ";");
            break;
        }
