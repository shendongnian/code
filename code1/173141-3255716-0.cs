    using System;
    using System.Reflection;
    
    class Addition
    {
        public Addition(int a)
        {
            Console.WriteLine("Constructor called, a={0}", a);
        }
    }
    
    class Test
    {
        static void Main()
        {
            Type type = typeof(Addition);
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int) });
            object instance = ctor.Invoke(new object[] { 10 });
        }
    }
