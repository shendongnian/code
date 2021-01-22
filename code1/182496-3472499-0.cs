    [DataContract]
    public class classA {
        [DataMember]
        private classB b = new classB();
        public classB B { get {return b; } }
    }
