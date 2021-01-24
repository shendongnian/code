    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registering Resolving Handler...");
            AppDomain.CurrentDomain.AssemblyResolve += MyHandler;
            Console.WriteLine("Creating shared library...");
            SharedLibWrapper sharedLib = new SharedLibWrapper();
            Console.WriteLine("The version is {0}", sharedLib.Version);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();
        }
        static string GetSharedAssemblyPath()
        {
            string relativePath = @"..\..\..\SharedAssemblies\";
            return Path.GetFullPath(relativePath);
        }
        static Assembly MyHandler(object source, ResolveEventArgs e)
        {
            Console.WriteLine("Resolving {0}", e.Name);
            if (e.Name.Contains("MyLibrary"))
            {
                string path = GetSharedAssemblyPath() + @"MyLibrary.dll";
                Console.WriteLine("Resolving to path {0}", path);
                return Assembly.LoadFile(path);
            }
            return null;
        }
    }
