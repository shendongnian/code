        static void Main(string[] args)
        {
            // Load the assembly    
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assemblyName = Path.Combine(directory, "YourAnyCPUApplication.exe");
            Assembly assembly = Assembly.LoadFile(assemblyName);
            assembly.EntryPoint.Invoke(null, null);
        }
