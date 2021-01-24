    public static void main(string[] args)
    {
        // only the core .NET assemblies loaded so far...
        Console.PrintLine("Something");
        // call a method using another assembly's components/objects...
        CallToAnotherAssembly();
    }
    private static void CallToAnotherAssembly()
    {
        // in order for the JIT to execute this, it needs to load the
        // other assembly into memory and create the object. NOW it's
        // in memory and affecting your startup
        var objectInAnotherAssembly = new ObjectInAnotherAssembly();
    }
