    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            MethodInfo method = typeof(string).GetMethod
                ("ToUpper", BindingFlags.Instance | BindingFlags.Public,
                 null, new Type[]{}, null);
                                                      
            Func<string, string> func = (Func<string, string>)
                Delegate.CreateDelegate(typeof(Func<string, string>),
                                        null,
                                        method);
            
            string x = func("hello");
            
            Console.WriteLine(x);
        }
    }
