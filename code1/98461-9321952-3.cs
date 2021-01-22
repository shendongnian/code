    static void ProcessFile(string file)
    {
        try
        {
            Assembly a = Assembly.LoadFile(file);
            Console.WriteLine(a.GetName().FullName);
        }
        catch { /* do nothing */ }
    }
    static void ProcessFolder(string folder)
    {
        foreach (string file in Directory.GetFiles(folder))
        {
            ProcessFile(file);
        }
        foreach (string subFolder in Directory.GetDirectories(folder))
        {
            ProcessFolder(subFolder);
        }
    }
    static void Main(string[] args)
    {
        ProcessFolder(@"C:\Windows\Assembly");
    }
