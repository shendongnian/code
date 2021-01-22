    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.IO;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var x = Foo().OrderBy(t => t.FullName).Select(t => t.FullName);
                var y = Bar().OrderBy(t => t.FullName).Select(t => t.FullName);
                File.WriteAllLines("a.txt", x.ToArray());
                File.WriteAllLines("b.txt", y.ToArray());
                Console.ReadKey();
            }
            private static List<Assembly> Foo()
            {
                List<Type> toInstantiate = AppDomain.CurrentDomain
                    .GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                    .ToList();
                return toInstantiate.Select(t => t.Assembly).Distinct().ToList();
            }
            private static List<Assembly> Bar()
            {
                List<Type> toInstantiate = new List<Type>();
                List<Type> allTypes = AppDomain.CurrentDomain
                    .GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                    .ToList();
                foreach (Type t in allTypes)
                {
                    toInstantiate.Add(t);
                }
                return toInstantiate.Select(t => t.Assembly).Distinct().ToList();
            }
        }
    }
