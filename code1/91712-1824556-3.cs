    public class JsonUser
    {
        public long id { get; set; }
        public string name { get; set; }
        public string dateJoined { get; set; }
        ...
        public JsonUser(User user)
        {
            id = user.ID;
            name = user.Name;
            dateJoined = user.DateJoined.ToString("yyyy-MM-dd");
            ...
        }
    }
