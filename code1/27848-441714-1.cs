    class Program
        {
            static void Main(string[] args)
            {
                string assemblyPath = args[0];
                Assembly loadedAssembly = Assembly.LoadFrom(assemblyPath);
                Module[] modules = loadedAssembly.GetModules();
                Console.WriteLine("Assembly: " + loadedAssembly.GetType().Name);
                foreach (Module module in modules)
                {
                    Console.WriteLine("Module: {0}\nFullyQualifiedName: {1}", module.Name, module.FullyQualifiedName);
                    Type[] types = module.GetTypes();
                    foreach (Type type in types)
                    {
                    Console.WriteLine("Type: {0}\n FullName: {1}", type.Name, type.FullName);    
                    }
                }
                Console.ReadLine();
            }
        }
