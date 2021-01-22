    using System;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            var proc = new XProcessingInstruction
                ("xml-stylesheet", "type=\"text/xsl\" href=\"Sample.xsl\"");
            doc.Root.AddBeforeSelf(proc);
            doc.Save("test2.xml");
        }
    }
