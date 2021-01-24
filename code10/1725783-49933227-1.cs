    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                var enumsInAssembly = Assembly.GetExecutingAssembly()
                                              .GetTypes()
                                              .Where(type => type.IsEnum);
    
                Console.WriteLine(enumsInAssembly.Count());
                Console.Read();
            }
        }
    
        enum MyEnumA { }
        enum MyEnumB { }
        enum MyEnumC { }
    }
