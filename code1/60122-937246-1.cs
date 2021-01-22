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
                // note that there's no checking here that the object really
                // is a collection and thus really has the attribute
                String indexerName = ((DefaultMemberAttribute)collection.GetType()
                    .GetCustomAttributes(typeof(DefaultMemberAttribute),
                     true)[0]).MemberName;
                PropertyInfo pi2 = collection.GetType().GetProperty(indexerName);
                Object value = pi2.GetValue(collection, new Object[] { 0 });
                
                Console.Out.WriteLine("tc.Values[0]: " + value);
                Console.In.ReadLine();
            }
        }
    }
