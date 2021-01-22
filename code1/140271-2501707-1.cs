    [DataContract]
    class Foo {
        public Foo (string name) {
            Name1 = name;
            Name2 = name;
        }
        [DataMember]
        public string Name1 { get; private set; }
        [DataMember]
        private string Name2;
    }
