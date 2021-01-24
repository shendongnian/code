    class Program
        {
            static void Main(string[] args)
            {
                var asl = new AssemblyLoader();
                var asm = asl.LoadFromAssemblyPath(@"C:\temp\Microsoft.AspNetCore.Antiforgery.dll");
                try
                {
                    var y = asm.GetExportedTypes();
                    Console.WriteLine(y);
                }
                catch (Exception e1)
                {
                    
                    Console.Write(e1.Message);
                    var deped = asl.CallForDependency(asm.GetName());
                    Console.WriteLine(deped.ToString());
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
    
                public Assembly CallForDependency(AssemblyName assemblyName)
                {
                    return this.Load(assemblyName);
                }
            }
        }
