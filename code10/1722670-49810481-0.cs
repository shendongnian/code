    public static void Main()
    {
        // Use the file name to load the assembly into the current
        // application domain.
        Assembly a = Assembly.Load("ClassLibrary1.dll");
        // Get the type to use.
        Type myType = a.GetType("Class1");
        // Get the method to call.
        MethodInfo myMethod = myType.GetMethod("iscalled");
        // Create an instance.
        object obj = Activator.CreateInstance(myType);
        // Execute the method.
        myMethod.Invoke(obj, null);
    }
