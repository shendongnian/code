    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication53
    {
        class Program
        {
            static void Main(string[] args)
            {
                string ident = "<?xml version=\"1.0\"?><c_TemplaceSaver xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></c_TemplaceSaver>";
                XDocument doc = XDocument.Parse(ident);
                XElement c_TemplateSaver = doc.Root;
                c_TemplateSaver.Add(new XElement("ABC", 123));
            }
        }
    }
