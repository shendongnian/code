    using System;
    
    namespace ConsoleApplication1 {
        class Program {
            class Base { }
            class Derived : Base { }
            class OtherClass { };
    
            static void Main(string[] args) {
                Base b = new Base();
                Derived d = new Derived();
                OtherClass oc = new OtherClass();
    
                TestObject(b);
                TestObject(d);
                TestObject(oc);
            }
    
            static void TestObject(object o) {
                Type baseType = typeof(Base);
                Type paramType = o.GetType();
                Console.WriteLine("Type of o: {0}", paramType.Name);
                Console.WriteLine("o is Base: {0}", o is Base);
                Console.WriteLine("o is IsInstanceOfType Base: {0}", baseType.IsInstanceOfType(o));
                Console.WriteLine("o is IsSubclassOf Base: {0}", paramType.IsSubclassOf(baseType));
                Console.WriteLine("o is of type Base: {0}", baseType == paramType);
                Console.WriteLine();
            }
        }
    }
