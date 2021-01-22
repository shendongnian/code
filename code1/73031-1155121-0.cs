    [DataContract]
    public class Person {
        [DataMember]
        private int id;
        public int Id {get {return id;}} // immutable
        public Person(int id) { this.id = id; }
        [DataMember]
        public string Name {get;set;} // mutable
    }
