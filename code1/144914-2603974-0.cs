    [DataContract]
    public class Customer
    {
        [IgnoreDataMember]
        public Age Age { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
