    using System;
    using System.Linq;
    
    [AttributeUsage(AttributeTargets.All)]
    public class FooAttribute : Attribute {}
    
    class Test
    {
        static void Main()
        {
            var query = typeof(Test).GetMethods()
                .Where(method => method.GetCustomAttributes(
                                  typeof(FooAttribute), false).Length != 0);
                
            foreach (var method in query)
            {
                Console.WriteLine(method);
            }
        }
        
        [Foo]
        public static void MethodWithAttribute1() {}
        
        [Foo]
        public static void MethodWithAttribute2() {}
    
        public static void MethodWithoutAttribute() {}
        
    }
