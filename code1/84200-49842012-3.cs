    using System.IO;
    using System.Reflection;
    public static class Program
    {
        public static string ExecutablePath
        {
            get;
            private set;
        }
        static Program()
        {
            var assemblyPath = Assembly.GetEntryAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            if (assemblyDirectory.EndsWith(@"\Debug") || assemblyDirectory.EndsWith(@"\Release"))
            {
                string projectFile = Path.GetFileNameWithoutExtension(assemblyPath) + ".csproj";
                var root = new DirectoryInfo(assemblyDirectory);
                while (root.Parent != null)
                {
                    if (File.Exists(Path.Combine(root.FullName, projectFile)))
                        break;
                    root = root.Parent;
                    if (root.Parent == null) // we could not find it (should not happen)
                        ExecutablePath = assemblyDirectory;
                }
                ExecutablePath = root.FullName;
            }
            else
            {
                ExecutablePath = assemblyDirectory;
            }
        }
    }
