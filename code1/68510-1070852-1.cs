    using System;
    using System.Linq;
    
    class Test
    {    
        static void Main()
        {
            ShowRefsInAssemblyContaining(typeof(string));
        }
        
        static void ShowRefsInAssemblyContaining(Type exampleType)
        {
            var query = from type in exampleType.Assembly.GetTypes()
                        where type.IsPublic
                        from method in type.GetMethods()
                        where method.GetParameters()
                                    .Any(p => p.ParameterType.IsByRef &&
                                             !p.IsOut)
                        select method;
            
            foreach (var method in query)
            {
                Console.WriteLine(method.DeclaringType + ": " + method);
            }
        }
    }
        
