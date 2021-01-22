    [XmlRoot("c1")]
    public class Class1
    {
        [XmlArray("items")]
        [XmlArrayItem("c2")] 
        public Class2[] Items;
    }
