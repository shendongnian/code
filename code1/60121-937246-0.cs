    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    namespace DemoApp
    {
        public class TestClass
        {
            public List<Int32> Values { get; private set; }
    
            public TestClass()
            {
                Values = new List<Int32>();
                Values.Add(10);
            }
        }
    
        class Program
        {
            static void Main()
            {
                TestClass tc = new TestClass();
    
                PropertyInfo pi1 = tc.GetType().GetProperty("Values");
                Object collection = pi1.GetValue(tc, null);
    
                PropertyInfo pi2 = collection.GetType().GetProperty("Item");
                Object value = pi2.GetValue(collection, new Object[] { 0 });
                
                Console.Out.WriteLine("tc.Values[0]: " + value);
                Console.In.ReadLine();
            }
        }
    }
