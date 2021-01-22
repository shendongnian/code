    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ReflectionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                Type typeToCreate = thisAssembly.GetTypes().Where(t => t.Name == "Program").First();
                
                object myProgram = Activator.CreateInstance(typeToCreate);
    
                Console.WriteLine(myProgram.ToString());
            }
        }
    }
