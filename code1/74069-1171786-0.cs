        public class Element
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            string xml =
                @"<Elements>
    <Element>
        <Name>Value</Name>
        <Type>Value</Type>
        <Color>Value</Color>
    </Element>(...)</Elements>";
    XmlSerializer serializer = new XmlSerializer(typeof(Element[]), new XmlRootAttribute("Elements"));
            Element[] result = (Element[])serializer.Deserialize(new StringReader(xml));}
