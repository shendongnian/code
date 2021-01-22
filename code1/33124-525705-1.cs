    [DataContract]
    class MyData {
        [DataMember]
        public int Foo {get;set;} // is sent
        public int Bar {get {...} set {...}} // is ignored
    }
