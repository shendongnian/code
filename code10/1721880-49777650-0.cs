    public class Root
    {
        public string[] Elements { get; set; }
    
        public string GetXmlString()
        {
            var rootElement = new XElement("Root");
            for (var i = 0; i < Elements.Length; i++)
            {
                var tag = $"Element_{(i + 1).ToString().PadLeft(2, '0')}";
                var xElement = new XElement(tag, Elements[i]);
                rootElement.Add(xElement);
            }
    
            return rootElement.ToString();
        }
    
        public static Root DeserializeXmlString(string xmlString)
        {
            var rootElement = XElement.Parse(xmlString);
            var elementsArray = rootElement
                .Elements()
                .Select(xElement => xElement.Value)
                .ToArray();
    
            return new Root {Elements = elementsArray};
        }
    }
