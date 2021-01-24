    public class Person
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Role> Roles { get; set; }
    }
    public class Role
    {
        public string name { get; set; }
        public string type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string town { get; set; }
    }
