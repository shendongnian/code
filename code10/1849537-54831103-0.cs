    public class Example
    {
        public string id { get; set; }
        public int number { get; set; }
        [JsonIgnore]
        public Perspective configured_perspective { get; set; }
        [DataMember(Name = "configured_perspective")]
        private string configured_perspective_serialized
        {
            get => configured_perspective?.ToString();
            set => configured_perspective = new Perspective(value);
        }
    }
