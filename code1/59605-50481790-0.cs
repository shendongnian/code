    static void Main(string[] args)
        {
            try
            {
                var root = @"G:\logs";
                DirectorySearch(root);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    public static void DirectorySearch(string root, bool isRootItrated = false)
    {
        if (!isRootItrated)
        {
            var rootDirectoryFiles = Directory.GetFiles(root);
            foreach (var file in rootDirectoryFiles)
            {
                Console.WriteLine(file);
            } 
        }
        var subDirectories = Directory.GetDirectories(root);
        if (subDirectories?.Any() == true)
        {
            foreach (var directory in subDirectories)
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                DirectorySearch(directory, true);
            }
        }
    }
