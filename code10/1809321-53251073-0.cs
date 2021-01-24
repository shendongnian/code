    public class pet
    {
        public string name { get; set; }
        [XmlElementAttribute(DataType = "date")]
        public DateTime dateOfBirth { get; set; }
    }
