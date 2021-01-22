    static void Main(string[] args)
        {
            DirectoryInfo sourceDir = new DirectoryInfo("c:\\a");
            DirectoryInfo destinationDir = new DirectoryInfo("c:\\b");
    
            CopyDirectory(sourceDir, destinationDir);
    
        }
    
        static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }
    
            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, 
                    file.Name));
            }
    
            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName, dir.Name);
    
                // Call CopyDirectory() recursively.
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }
