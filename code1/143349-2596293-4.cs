    [XmlRoot("Post", Namespace="http://www.example.com/webservices/2010/04")]
    public class Post1_1
    {
        public Int32 AuthorId { get; set; }
        public DateTime Posted { get; set; }
        public String Title { get; set; }
        public PostType @Type { get; set; }
        [XmlIgnore]
        public DateTime LastEdited { get; set; }
        [XmlElement("LastEdited")]
        public String LastEdited_Surrogate
        {
            get
            {
                if (LastEdited > (DateTime.UtcNow - new TimeSpan(24,0,0)))
                    return "Today";
                else if (LastEdited > (DateTime.UtcNow - new TimeSpan(48,0,0)))
                    return "Yesterday";
                else
                    return LastEdited.ToString();
            }
            set
            {
                if (value == "Today")
                    LastEdited = DateTime.UtcNow;
                else if (value == "Yesterday")
                    LastEdited = DateTime.UtcNow - new TimeSpan(24,0,0);
                else
                    LastEdited = DateTime.Parse(value);
            }
        }
    }
 
