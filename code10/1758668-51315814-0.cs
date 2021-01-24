    class Program
    {
        static void Main(string[] args)
        {
            string str = @"<departments>
                              <department id = ""1"" name = ""Sporting Goods"">
                                   <products>
                                     <product name=""Basketball"" price=""9.99"">
                                          <add key = ""Color"" value = ""Orange""/>
                                          <add key = ""Brand"" value = ""[BrandName]""/>
                                     </product>
                                   </products>
                              </department>
                           </departments>";
            XmlDocument xmlDoc = LoadXmlsFromString(str);
            string productXpath = "descendant-or-self::product";
            var nodes = ExtractNodes(xmlDoc, productXpath);
            foreach (XmlNode childrenNode in nodes)
            {
                var node = childrenNode.SelectSingleNode("descendant-or-self::*")?.OuterXml;
                var obj = Product.Deserialize(node);
            }
        }
        private static XmlNodeList ExtractNodes(XmlDocument xmlDoc, string xpath)
        {
            var nodes = xmlDoc.SelectNodes(xpath);
            return nodes;
        }
        private static XmlDocument LoadXmlsFromString(string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            return xmlDoc;
        }
    }
