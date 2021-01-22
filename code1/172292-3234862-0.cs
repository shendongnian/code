    using System;
    using System.Linq;
    using System.Xml;
    
    class Test
    {
        static void Main(string[] args)
        {
            string xml = 
    @"<elements>
        <![CDATA[-div[id|dir|class|align|style],-span[class|align]]]>
    </elements>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlCDataSection cdata = doc.DocumentElement
                                       .ChildNodes
                                       .OfType<XmlCDataSection>()
                                       .First();
            cdata.Value = "-div[id|dir|class|align|style],-span[class|align|style]";
            doc.Save(Console.Out);
        }
    }
