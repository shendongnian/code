    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        public class MyClass
        {
            private string _property1;
            private string _property2;
    
            public string Property1 {
                get { return this._property1; }
                set { this._property1 = value; }
            }
            
            public string Property2 {
                get { return this._property2; }
                set { this._property2 = value; }
            }
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
