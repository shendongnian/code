    [KnownType(typeof(List<string>))]
    [DataContract]
    public class YourClass
    {
        [DataMember]
        public List<object> YourList { get; set; }
    }
