    using System;
    using System.Collections;
    using System.Linq;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            Assembly assembly = typeof(string).Assembly;
            Type target = typeof(IEnumerable);        
            var types = assembly.GetTypes()
                                .Where(type => target.IsAssignableFrom(type));
            
            foreach (Type type in types)
            {
                Console.WriteLine(type.Name);
            }
        }
    }
