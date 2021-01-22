    [DataContract]
    public class Foo {
        [DataMember]
        public int Bar {get;set;} // simple data
        [DataMember]
        private string DoSomeThinking {
            get {.... serialize the complex data ....}
            set {.... deserialize the complex data ....}
        }
    }
