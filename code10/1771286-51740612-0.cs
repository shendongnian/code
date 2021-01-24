    public static void Main()
    {
        string filetype = ".jpg";
        // Make a reference to a directory.
        DirectoryInfo di = new DirectoryInfo("c:\\");
        // Get a reference to each file in that directory.
        FileInfo[] fiArr = di.GetFiles("*" + filetype, SearchOption.AllDirectories);
        // Display the names and sizes of the files.
        Console.WriteLine("The directory {0} contains the following files:", di.Name);
        foreach (FileInfo f in fiArr)
            Console.WriteLine("The size of {0} is {1} bytes.", f.Name, f.Length);
    }
