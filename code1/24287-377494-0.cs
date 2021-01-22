    [Serializable]
    public class MyCollectionWrapper {
        [XmlAttribute]
        public string SomeProp {get;set;} // custom props etc
        [XmlAttribute]
        public int SomeOtherProp {get;set;} // custom props etc
        public Collection<string> Items {get;set;} // the items
    }
