    using System;
    using System.Reflection;
    
    public class Test
    {
        static void Main()
        {
            Assembly mscorlib = typeof(string).Assembly;
            string name = "System.Deployment.Internal.Isolation.IDefinitionAppId";
            Type type = mscorlib.GetType(name);
            
            // Prints System.Deployment.Internal.Isolation
            Console.WriteLine(type.Namespace);
        }
    }
