    private static string ExecutingFolder()
    {
        string exeUri = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        Uri uri = new Uri(exeUri);
        string physicalExePath = uri.LocalPath;
        return IO.Path.GetDirectoryName(physicalExePath);
    }
