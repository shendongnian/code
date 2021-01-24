    using Newtonsoft.Json;
    public class Post
    {
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "id ")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title ")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "body ")]
        public string Body { get; set; }
    }
