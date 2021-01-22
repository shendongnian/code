    // Load the assembly
    Assembly assembly = Assembly.LoadFrom(@"c:\path\Tools.dll");
    // Select a type
    Type type = assembly.GetType("Tools.Utility");
    // invoke a method on this type
    type.InvokeMember("SomeMethod", BindingFlags.Static, null, null, new object[0]);
