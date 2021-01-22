    using System;
    using System.Reflection;
    
    public class Test
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        
        public void AddPropertyValue(string name, string value)
        {
            PropertyInfo property = typeof(Test).GetProperty(name);
            if (property == null)
            {
                throw new ArgumentException("No such property!");
            }
            // More error checking here, around indexer parameters, property type,
            // whether it's read-only etc
            property.SetValue(this, value, null);
        }
        
        static void Main()
        {
            Test t = new Test();
            t.AddPropertyValue("Foo", "hello");
            t.AddPropertyValue("Bar", "world");
            
            Console.WriteLine("{0} {1}", t.Foo, t.Bar);
        }
    }
