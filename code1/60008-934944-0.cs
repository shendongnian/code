    using System;
    using System.Reflection;
    
    public class Test
    {
        private readonly string foo = "Foo";
        
        public static void Main()
        {
            Test test = new Test();
            FieldInfo field = typeof(Test).GetField
                ("foo", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(test, "Hello");
            Console.WriteLine(test.foo);
        }        
    }
