    [DataContract]
    public class Customer {
        [DataMember(Order=1)]
        public int {get;set;}
        [DataMember(Order=2)]
        public string Name {get;set;}
    }
