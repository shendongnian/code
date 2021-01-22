    using System;
    using System.Collections.Generic;
    namespace Test {
        class MyClass { 
        }
        class MyClassList {
            protected List<MyClass> _list = new List<MyClass>();
            public void Add(MyClass m) { 
                // your validation here...
                _list.Add(m);
            }
            public void Remove(MyClass m) {
                // your validation here...
                _list.Remove(m);
            }
            public IEnumerator<MyClass> GetEnumerator() {
                return _list.GetEnumerator();
            }
        }
        class Program {
            static void Main(string[] args) {
                MyClassList l = new MyClassList();
                l.Add(new MyClass());
                // iterate
                foreach (MyClass m in l) { 
                }
            }
        }
    }
