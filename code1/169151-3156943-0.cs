    public static void Main()
    {
        LoadCorrectDLLs();
        // .NET will ensure DotNetZip is loaded at this point.
        MethodInThisAssembly();
    }
    public static void MethodInThisAssembly()
    {
        // Since MethodInThisAssembly uses DotNetZip,
        //  its assembly will get loaded immediately before this method is called.
        IDotNetZipInterface x = null;
        ...
    }
    public static void LoadCorrectDLLs()
    {
        // p/Invoke LoadLibrary to load the correct version of DotNetZip.
    }
