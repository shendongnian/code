    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public int resource { get; set; }
        public string firstname { get; set; }
    }
    public class Token
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public User user { get; set; }
    }
