    using System;
    
    // Mutable structs - just say no...
    public struct Foo
    {
        public string Text { get; set; }
    }
    
    public class Test
    {
        static void Main()
        {
            Type type = typeof(Foo);
            
            object value = Activator.CreateInstance(type);
            var property = type.GetProperty("Text");
            property.SetValue(value, "hello", null);
            
            Foo foo = (Foo) value;
            Console.WriteLine(foo.Text);
        }
    }
