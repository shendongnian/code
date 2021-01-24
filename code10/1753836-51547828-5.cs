	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.Loader;
	using Microsoft.Extensions.DependencyModel;// add this nuget
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
                Console.WriteLine("Got exception at first attempt of GetExportedTypes ");
                Console.WriteLine("\t*********" + e1.Message + "**************");
                var deped = asl.CallForDependency(asm.GetName());
                try
                {
                    Console.WriteLine("\n" + deped.ToString());
                    Console.WriteLine("----------All Exported Types------------");
                    foreach (var item in deped.ExportedTypes)
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine("Got exception at second attempt of GetExportedTypes ");
                    Console.WriteLine("\t*********" + e2.Message + "**************");
                }
            }
            Console.ReadLine();
        }
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
