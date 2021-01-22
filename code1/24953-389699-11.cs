    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        public class MyClass
        {
            public MyClass() { }
    
            public string Property1 { get; set; }
            public string Property2 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<MyClass> x = new List<MyClass>();
                x.Add(new MyClass
                {
                    Property1 = "Kev", 
                    Property2 = "Kev 2"
                });
            }
        }
    }
