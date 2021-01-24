    public class LoginDetail
    {
        public bool ok { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string name_f { get; set; }
        public string name_l { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public Subscriptions subscriptions { get; set; }
        public object[] categories { get; set; }
        public object[] groups { get; set; }
        public string[] resources { get; set; }
    }
    public class Subscriptions
    {
        [JsonProperty("1")]
        public string _1 { get; set; }
        [JsonProperty("4")]
        public string _4 { get; set; }
        [JsonProperty("5")]
        public string _5 { get; set; }
        [JsonProperty("6")]
        public string _6 { get; set; }
    }
