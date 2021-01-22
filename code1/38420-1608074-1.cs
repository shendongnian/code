    public class UserHolder
    {
        private List<User> users = null;
        public UserHolder()
        {
        }
        [XmlElement("user")]
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }
    }
