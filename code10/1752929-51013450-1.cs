    [Serializable]
    [XmlType("User")]
    public class MainData
    {
        public int UserId { get; set; }
        [XmlElement("LoginData")]
        public LoginData TestLoginData { get; set; }
        [XmlElement("UserData")]
        public UserData TestUserData { get; set; }
    }
