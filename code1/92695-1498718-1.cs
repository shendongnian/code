    using System;
    using System.Reflection;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Type type = typeof(Base);
                PropertyInfo prop = type.GetProperty("Value");
                Console.Out.WriteLine("Base.Value.CanRead: " + prop.CanRead);
                Console.Out.WriteLine("Base.Value.CanWrite: " + prop.CanWrite);
    
                type = typeof(Derived);
                prop = type.GetProperty("Value");
                Console.Out.WriteLine("Derived.Value.CanRead: " + prop.CanRead);
                Console.Out.WriteLine("Derived.Value.CanWrite: " + prop.CanWrite);
    
                Derived d = new Derived();
                d.Value = "Test";
                Console.Out.WriteLine("Derived.Value: " + d.Value);
                Console.Out.WriteLine("Reflected value: " + prop.GetValue(d, null));
    
                Console.In.ReadLine();
            }
        }
    
        public class Base
        {
            public virtual String Value { get; set; }
        }
    
        public class Derived : Base
        {
            public override string Value
            {
                set
                {
                    base.Value = value;
                }
            }
        }
    }
