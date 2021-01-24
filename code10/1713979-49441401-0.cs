    public class UserList
    {
        public string user_id { get; set; }
        public string secondUser_id { get; set; }
        public string member_since { get; set; }
        public string member_since_date { get; set; }
        public string function { get; set; }
        public string rank_int { get; set; }
        public string status { get; set; }
    }
    
    public class JsonData
    {
        public List<UserList> user_list { get; set; }
        public int returned { get; set; }
    }
