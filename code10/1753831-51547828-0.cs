     class Program
        {
            static void Main(string[] args)
            {
                var asl = new AssemblyLoader();
                var asm = asl.LoadFromAssemblyPath(@"C:\temp\Microsoft.AspNetCore.Antiforgery.dll");
                try
                {
                    var y = asm.GetExportedTypes();
                }
                catch (Exception e1)
                {
                    Console.Write(e1.Message);
                }
                Console.ReadLine();
    
            }
    
            public class AssemblyLoader :AssemblyLoadContext
            {
                protected override Assembly Load(AssemblyName assemblyName)
                {
                    var deps = DependencyContext.Default;
                    var res = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
                    var assembly = Assembly.Load(new AssemblyName(res.First().Name));
                    return assembly;
                }
            }
        }
