    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XElement element = new XElement("tag",
                                            "Brackets & stuff <>");
            
            Console.WriteLine(element);
        }
    }
