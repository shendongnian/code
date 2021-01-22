    [DataContract]
    public class Root {
        [DataMember]
        public List<SubItem> Nodes {get;private set;}
    }
    [DataContract]
    public class SubItem {
        [DataMember]
        public int Foo {get;set;}
        [DataMember]
        public string Bar {get;set;}
    }
