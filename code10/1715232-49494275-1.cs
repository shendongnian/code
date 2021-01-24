    using System;
    using System.Reflection;
    using Test2;
    
    namespace NetCore2._0
    {
        class Program
        {
            static void Main(string[] args)
            {
                var typeName = typeof(Test2.Class1).AssemblyQualifiedName;
                var type = Type.GetType(typeName);
    
                Console.WriteLine(Assembly.GetExecutingAssembly().FullName);
                var myObject = Activator.CreateInstance(type) as Class1;
                Console.WriteLine(myObject.CallMe());
            }
    
        }
    }
