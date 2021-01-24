    public static void Main(string[] args)
    {
        var dllPath = args[0]; // "D:\Test\bin\Release\netcoreapp2.0\my.dll"
        var assembly = Assembly.LoadFrom(dllPath);
        var types = assembly.GetExportedTypes(); // Throws exception
    }
