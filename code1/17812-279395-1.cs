    using System;
    using System.Reflection;
    
    public class Test
    {
        private int foo;
        
        public int Foo { get { return foo; } }
        
        static void Main()
        {
            var prop = typeof(Test).GetProperty("foo",
                                                BindingFlags.Public
                                                | BindingFlags.Instance 
                                                | BindingFlags.IgnoreCase);
            Console.WriteLine(prop);
        }
    }
