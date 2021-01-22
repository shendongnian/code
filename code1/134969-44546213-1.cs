    public static class AssemblyLoader
    {
        private static readonly ConcurrentDictionary<string, bool> AssemblyDirectories = new ConcurrentDictionary<string, bool>();
        static AssemblyLoader()
        {
            AssemblyDirectories[GetExecutingAssemblyDirectory()] = true;
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
        }
        public static Assembly LoadWithDependencies(string assemblyPath)
        {
            AssemblyDirectories[Path.GetDirectoryName(assemblyPath)] = true;
            return Assembly.LoadFile(assemblyPath);
        }
        private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            string dependentAssemblyName = args.Name.Split(',')[0] + ".dll";
            List<string> directoriesToScan = AssemblyDirectories.Keys.ToList();
            foreach (string directoryToScan in directoriesToScan)
            {
                string dependentAssemblyPath = Path.Combine(directoryToScan, dependentAssemblyName);
                if (File.Exists(dependentAssemblyPath))
                    return LoadWithDependencies(dependentAssemblyPath);
            }
            return null;
        }
        private static string GetExecutingAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
