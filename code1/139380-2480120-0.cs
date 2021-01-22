    public class MyClass
    {
        public string Name {get;set;}
        [XmlArray("ItemValues")]
        [XmlArrayItem("ItemValue")]
        public Items MyItems {get;set;}
    }
