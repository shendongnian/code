    [Serializable]
    [DataContract]
    public class Customer
    
    {
        [DataMember]
        public int Age { get; set; }
    
        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        public int Number { get; set; }
    
        [DataMember]
        public string FullName { get; set; }
    
        [XmlIgnore]
        public int IgnoredNumber { get; set; }
    }
