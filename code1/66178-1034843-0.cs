    using System;
    using System.Reflection;
    
    public class Demo
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public string Baz { get; set; }
    }
    
    public class Test
    {
        static void Main()
        {
            Demo demo = new Demo { 
                Foo = "foo value", 
                Bar = "bar value", 
                Baz = "surprise!"
            };
            ShowProperty(demo, "Foo");
            ShowProperty(demo, "Bar");
            ShowProperty(demo, "Baz");
            ShowDemoProperty(demo, "Foo");
            ShowDemoProperty(demo, "Bar");
            ShowDemoProperty(demo, "Baz");
        }
        
        // Here we don't know the type involved, so we have to use reflection
        static void ShowProperty(object x, string propName)
        {
            PropertyInfo property = x.GetType().GetProperty(propName);
            if (property == null)
            {
                Console.WriteLine("No such property: {0}", propName);
            }
            else
            {
                Console.WriteLine("{0}: {1}", propName,
                                              property.GetValue(x, null));
            }
        }
        
        // Here we *know* it's a Demo
        static void ShowDemoProperty(Demo demo, string propName)
        {
            string value;
            
            // Note that this is very refactoring-unfriendly. Generally icky!
            switch (propName)
            {
                case "Foo": value = demo.Foo; break;
                case "Bar": value = demo.Bar; break;
                case "Baz": value = demo.Baz; break;
                default:
                    Console.WriteLine("No such property: {0}", propName);
                    return;
            }
            Console.WriteLine("{0}: {1}", propName, value);
                
        }
    }
