    public static void Main(string[] args)
    {
        var dllPath = args[0]; // "D:\Test\bin\Release\netcoreapp2.0\my.dll"
        var assembly = AssemblyLoader.LoadFromAssemblyPath(dllPath);
        var types = assembly.GetExportedTypes(); // No exceptions
    }
