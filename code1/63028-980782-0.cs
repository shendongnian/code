    [XmlRoot("response")]
    public class MyResponse : MyCollection<int> { }
    
    [DataContract(Name = "response")]
    public class MyCollection<T>
    {
        [DataMember]
        [XmlElement("entry")]
        public List<T> entry { get; set; }
        [DataMember]
        public int index { get; set; }
    }
