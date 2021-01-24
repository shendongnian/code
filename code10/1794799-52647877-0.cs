    using System;
    using System.Xml.Linq;          
    
    public class Program
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            XNamespace ns = "http://tempuri.org/DataSet1.xsd";
            
            string id = doc.Root           // From the root...
                .Element(ns + "Language")  // select the Language direct child...
                .Element(ns + "Id")        // and the Id child of that...
                .Value;                    // and then take the text value
            Console.WriteLine(id);
        }
    }
