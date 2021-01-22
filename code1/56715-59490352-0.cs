    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class UserNode
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string userName { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string passWord { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }         
     }
     public class LoginNode 
     {
        public UserNode id { get; set; }
     }
