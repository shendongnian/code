    public class User
    {
        public string UserName {get;set;}
        public string Email {get;set;}
        [XmlElement]
        public Details[] Details {get;set;}
    }
