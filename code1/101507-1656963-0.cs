    // Extension Method
    public static class DirectoryExtension
    {
        public static void CreateDirectory(this DirectoryInfo root, string path)
        {
            if (!Directory.Exists(root.FullName))
            {
                Directory.CreateDirectory(root.FullName);
            }
    
            string combinedPath = Path.Combine(root.FullName, path);
            Directory.CreateDirectory(combinedPath);
        }
    }
    
    // Usage
    DirectoryInfo root = new DirectoryInfo(@"c:\Test");
    root.CreateDirectory("testing");
    root.CreateDirectory("testing123");
    root.CreateDirectory("testingabc");
    root.CreateDirectory(@"abc\123");
