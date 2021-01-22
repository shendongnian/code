    using System.IO;
    using System.Xml;
    using System.Xml.XPath;
. . .
        string xml = @"<poi>      
                         <city>stockholm</city>  
                         <country>sweden</countr>
                            <gpoint>        
                                <lat>51.1</lat>        
                                <lng>67.98</lng>    
                            </gpoint>
                       </poi>";
        XmlReaderSettings set = new XmlReaderSettings();
        set.ConformanceLevel = ConformanceLevel.Fragment;
        XPathDocument doc = 
            new XPathDocument(XmlReader.Create(new StringReader(xml), set));
        XPathNavigator nav = doc.CreateNavigator();
        Console.WriteLine(nav.SelectSingleNode("/poi/gpoint/lat"));
        Console.WriteLine(nav.SelectSingleNode("/poi/gpoint/lng"));
