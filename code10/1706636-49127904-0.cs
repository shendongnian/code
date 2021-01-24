    public class Security
    {
        [XmlAttribute("mustunderstand", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public int MustUnderstand { get; set; }
    
        public UsernameToken UsernameToken { get; set; }
    }
