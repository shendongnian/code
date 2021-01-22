    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            Console.WriteLine(doc.Declaration);
        }
    }
