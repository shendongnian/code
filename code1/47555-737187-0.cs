    [DataContract]
    [KnownType(typeof(Building))]
    abstract class Node {
        [DataMember]
        public int Foo {get;set;}
    }
    [DataContract]
    class Building : Node {
        [DataMember]
        public string Bar {get;set;}
    }
----------
    [DataContract] 
    [KnownType(typeof(Node))]
    abstract class Node {
        [DataMember]
        public int Foo {get;set;}
    }
    [KnownType(typeof(Building))]
    class Building : Node {
        [DataMember]
        public string Bar {get;set;}
    }
