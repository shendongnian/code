    using Newtonsoft.Json;
    using System;
    using System.Xml.Linq;
    
    public class ConvertXmlToJson
    {
        public string XmlToJson(string xml)
        {
            XDocument xdoc = XDocument.Parse(xml);
            return JsonConvert.SerializeXNode(xdoc);
        }
    }
