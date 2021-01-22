    using System.IO;
    using System.Reflection;
    public static class FileSystem
    {
        public static string CorrectExecutablePath
        {
            get;
            private set;
        }
        static FileSystem()
        {
            var assemblyPath = Assembly.GetEntryAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
    #if FROM_IDE
            string projectFile = Path.GetFileNameWithoutExtension(assemblyPath) + ".csproj";
            var root = new DirectoryInfo(assemblyDirectory);
            while (root.Parent != null)
            {
                if (File.Exists(Path.Combine(root.FullName, projectFile)))
                    break;
                root = root.Parent;
                if (root.Parent == null) // we could not find it (should not happen)
                {
                    CorrectExecutablePath = assemblyDirectory;
                    return;
                }
            }
            CorrectExecutablePath = root.FullName;
    #else
            CorrectExecutablePath = assemblyDirectory;
    #endif
        }
    }
