    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            var values = doc.Root
                .Elements("Field")
                .Elements("Value")
                .Select(x => x.Value);
            string joined = string.Join(",", values);
            Console.WriteLine(joined);
        }
    }
