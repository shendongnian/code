    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1 {
        class ObjectWithProperties {
            Dictionary<string, object> properties = new Dictionary<string,object>();
            public object this[string name] {
                get { 
                    if (properties.ContainsKey(name)){
                        return properties[name];
                    }
                    return null;
                }
                set {
                    properties[name] = value;
                }
            }
        }
        class Comparer<T> : IComparer<ObjectWithProperties> where T : IComparable {
            string m_attributeName;
            public Comparer(string attributeName){
                m_attributeName = attributeName;
            }
            public int Compare(ObjectWithProperties x, ObjectWithProperties y) {
                return ((T)x[m_attributeName]).CompareTo((T)y[m_attributeName]);
            }
        }
        class Program {
            static void Main(string[] args) {
                // create some objects and fill a list
                var obj1 = new ObjectWithProperties();
                obj1["test"] = 100;
                var obj2 = new ObjectWithProperties();
                obj2["test"] = 200;
                var obj3 = new ObjectWithProperties();
                obj3["test"] = 150;
                var objects = new List<ObjectWithProperties>(new ObjectWithProperties[]{ obj1, obj2, obj3 });
                // filtering:
                Console.WriteLine("Filtering:");
                var filtered = from obj in objects
                             where (int)obj["test"] >= 150
                             select obj;
                foreach (var obj in filtered){
                    Console.WriteLine(obj["test"]);
                }
                // sorting:
                Console.WriteLine("Sorting:");
                Comparer<int> c = new Comparer<int>("test");
                objects.Sort(c);
                foreach (var obj in objects) {
                    Console.WriteLine(obj["test"]);
                }
            }
        }
    }
