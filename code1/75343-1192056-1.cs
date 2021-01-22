    using System;
    using System.Collections.Generic;
    namespace Test {
        class MyClass { 
        }
        class Program {
            static void Main(string[] args) {
                // this is a specialized collection
                List<MyClass> list = new List<MyClass>();
                // add elements of type 'MyClass'
                list.Add(new MyClass());
                // iterate
                foreach (MyClass m in list) { 
                }
            }
        }
    }
