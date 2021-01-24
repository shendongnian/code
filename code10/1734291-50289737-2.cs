    using System;
    using System.Xml.Linq;
    
    public class Program 
    {
        public static void Main() 
        {
            var element = new XElement("foo", new XAttribute("key", "a\rb"));
            Console.WriteLine(element);
        }
    }
