    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement input = doc.Descendants("Input").Where(x => (string)x == "readOF").FirstOrDefault();
                input.ReplaceWith("<!--<Input>readOF</Input>-->");
                doc.Save(FILENAME);
           }
      
        }
     
     
    }
