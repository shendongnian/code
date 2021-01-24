    public class ContactDto
    {
        private string _fullname = String.Empty;
        public int id { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        [JsonIgnore]
        public string fullname {
            get { return this.first + " " + this.last; }
            set { _fullname = value; }
        }
    }
