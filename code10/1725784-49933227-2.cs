    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                var assemblyTypes = Assembly.GetExecutingAssembly()
                                            .GetTypes()
                                            .OrderBy(type => type.Name);
    
                var namespacesInAssembly = assemblyTypes.Select(type => type.Namespace)
                                                        .Distinct()
                                                        .OrderBy(name => name);
    
                var enumsInAssembly = assemblyTypes.Where(type => type.IsEnum)
                                                   .OrderBy(type => type.Name); ;
    
                var enumsInNamespaceB = enumsInAssembly.Where(@enum => @enum.Namespace.EndsWith(nameof(NamespaceB)))
                                                       .OrderBy(type => type.Name); ;
    
                var enumsInClassC = assemblyTypes.Where(type => type.IsClass)
                                                 .Where(type => type.Name == nameof(NamespaceC.ClassC))
                                                 .SelectMany(type => type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
                                                 .Where(type => type.IsEnum)
                                                 .OrderBy(type => type.Name);
    
                foreach (var @namespace in namespacesInAssembly)
                    Console.WriteLine($"Namespace found: {@namespace}");
    
                Console.WriteLine();
                Console.WriteLine($"Enums in Assembly: {enumsInAssembly.Count()}");
                Console.WriteLine();
                Console.WriteLine($"Enums in Namespace B: {enumsInNamespaceB.Count()}");
                Console.WriteLine();
                Console.WriteLine($"Enums in Class C: {enumsInClassC.Count()}");
                Console.WriteLine();
    
                foreach (var x in enumsInClassC)
                    Console.WriteLine(x.Name);
    
                Console.Read();
            }
        }
    
        namespace NamespaceA
        {
            enum MyEnumA { }
        }
    
        namespace NamespaceB
        {
            enum MyEnumB { }
        }
    
        namespace NamespaceC
        {
            public class ClassC
            {
                enum MyEnumC { }
                enum MyEnumD { }
            }
        }
    }
