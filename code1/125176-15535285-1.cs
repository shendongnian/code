    [Serializable, XmlRoot("Root")]
    public class Fields
    {
    
        [XmlArray("Fields")]
        [XmlArrayItem(ElementName = "Field")]
        public List<UserInfoField> Fields;
    }
    
    [Serializable, XmlRoot("Field")]
    public class UserInfoField
    {
        [XmlAttributeAttribute("name")]
        public string Name;
    
        [XmlText]
        public string Value;
    
        [XmlAttributeAttribute("look-up")]
        public bool LookUp;
    }
