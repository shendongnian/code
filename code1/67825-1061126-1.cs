    public class Root
    {
        public string Name;
        public XDocument XmlString;
    }
    Root t = new Root 
             {  Name = "Test", 
                XmlString = XDocument.Parse("<Foo>bar</Foo>")
             };
