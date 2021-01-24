    public class NotificationDetails
    {
        [JsonProperty(PropertyName = "id")]
        public string NotificationID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateSent { get; set; }
        public string TemplateUrl { get; set; }
        public dynamic Model { get; set; }
    }
