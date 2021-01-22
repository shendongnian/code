    [ProtoContract]
    class MyData {
        [ProtoMember(1)]
        public int Foo {get;set;} // is sent
        public int Bar {get {...} set {...}} // is ignored
    }
