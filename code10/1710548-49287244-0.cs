    [XmlRoot("Account")]
    public class Account
    {
        [XmlArray("UrmDevices", IsNullable = true)]
        [XmlArrayItem("UrmDevice")]
        public List<UrmDevice> UrmDevices { get; set; }
        [XmlElement("UrmDevice")] // shadow UrmDevices with different layout
        public List<UrmDevice> EvilUrmDevices {
            get { return UrmDevices; }
            set { UrmDevices = value; }
        }
        // disable serialize of one of the two
        public bool ShouldSerializeEvilUrmDevices() { return false; }
    
        [XmlAttribute]
        public string Id { get; set; }
    }
