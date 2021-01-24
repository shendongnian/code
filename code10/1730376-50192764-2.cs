    class Program
    {
        static void Main(string[] args)
        {
            byte[] rawAssembly = File.ReadAllBytes(@"D:\Projects\AppDomainTest\plugin.dll");
            PluginLoader plugin = new PluginLoader(rawAssembly);
            // Output: 
            // Hello from New Domain
            plugin.Test();
            // Output: 
            // Assembly: mscorlib
            // Assembly: ConsoleApp
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine($"Assembly: {asm.GetName().Name}");
            }
            Console.ReadKey();
        }
    }
