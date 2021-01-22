    static void Main(string[] args)
        {
            AssemblyLoader("System.Xml, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false);
            AssemblyLoader("System.Xml", false);
            AssemblyLoader("System.Drawing", true);
        }
    
        public static void AssemblyLoader(string LoadedAssemblyName, bool PartialName)
        {
            try
            {
                Assembly LoadedAssembly;
                Console.WriteLine("| Loading Assembly {0}", LoadedAssemblyName);
                if(PartialName == true)
                    LoadedAssembly = Assembly.LoadWithPartialName(LoadedAssemblyName);
                else
                    LoadedAssembly = Assembly.Load(LoadedAssemblyName);
    
                Console.WriteLine("Full Name: {0}", LoadedAssembly.FullName);
                Console.WriteLine("Location: {0}", LoadedAssembly.Location);
                Console.WriteLine("Code Base: {0}", LoadedAssembly.CodeBase);
                Console.WriteLine("Escaped Code Base: {0}", LoadedAssembly.EscapedCodeBase);
                Console.WriteLine("Loaded from GAC: {0}", LoadedAssembly.GlobalAssemblyCache);
            } catch(FileNotFoundException) {
                Console.WriteLine("EXCEPTION: Cannot load assembly.");
            }
        }
