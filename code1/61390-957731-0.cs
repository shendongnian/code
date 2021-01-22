    [DataContract]
    class Foo : IWhateverInterfaces {
        [DataMember]
        public string Bar {get;set;}
        [DataMember]
        public int Baz {get;set;}
        public float NotPartOfTheContract {get;set;}
        public event EventHandler AlsoNotPartOfTheContract;
    }
