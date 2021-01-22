    using System;
    using System.Xml.Linq;
    
    public class Test
    {
        public static void Main()
        {
            XElement where = XElement.Parse
                ("<Where><BeginsWith>...</BeginsWith></Where>");
            XElement beginsWith = where.Element("BeginsWith");
            beginsWith.Remove();
            where.Add(new XElement("And", beginsWith));
            Console.WriteLine(where);
        }        
    }
