    public class UserDto
    {
        public int ID { get; set; }
        public String Name { get; set; }
        [JsonView(JsonViews.Administrator)]
        public DateTime DateOfBirth { get; set; }
        [JsonView(JsonViews.Administrator)]
        public string Email { get; set; }
    }
