    public class NotificationContent
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
    public class PostObject
    {
        [JsonProperty("notification_content")]
        public NotificationContent NotificationContent { get; set; }
    }
