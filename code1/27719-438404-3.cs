    using System;
    //using System.Linq;
    namespace Foo {
        using System.Linq;
        class Program {
            static Program() {
                AppDomain.CurrentDomain.AssemblyLoad += (s, a) => {
                    Console.WriteLine(a.LoadedAssembly.FullName);
                };
            }
            static void Main() {            
                Console.WriteLine("pre-Bar");
                Bar();
                Console.WriteLine("post-Bar");
                Console.ReadLine();
            }
            static void Bar() {
                Console.WriteLine("pre-Max");
                int[] data = { 1, 2, 3, 4, 5 };
                Console.WriteLine("Max: " + Enumerable.Max(data));
                Console.WriteLine("post-Max");
            }
        }
    }
