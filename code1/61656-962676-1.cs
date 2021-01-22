    using System;
    using System.Linq;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(IsMicrosoftType(typeof(string)));
            Console.WriteLine(IsMicrosoftType(typeof(Test)));
        }
            
        static bool IsMicrosoftType(Type type)
        {
            object[] attrs = type.Assembly.GetCustomAttributes
                (typeof(AssemblyCompanyAttribute), false);
            
            return attrs.OfType<AssemblyCompanyAttribute>()
                        .Any(attr => attr.Company == "Microsoft Corporation");
        }
    }
