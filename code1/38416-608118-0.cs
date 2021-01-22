    public class UserHolder {
       [XmlElement("list")]
       public User[] Users { get; set; }
    
       [XmlIgnore]
       public List<User> UserList { get { return new List<User>(Users); } }
    }
