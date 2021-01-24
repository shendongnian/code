    public static void Main(string[] args)
    {
        foreach (var file in EnumFilesRecursively(@"C:\Program Files\"))
        {
            Console.WriteLine(file);
        }
    }
