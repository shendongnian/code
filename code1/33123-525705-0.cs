    [Serializable]
    public class MyData {
        public int Foo {get;set;} // is sent
        [XmlIgnore]
        public int Bar {get {...} set {...}} // is ignored
    }
