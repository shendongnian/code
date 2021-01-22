    [XmlRoot("root")]
    public class HasBase64Content
    {
        [XmlIgnore]
        public string Content { get; set; }
        [XmlElement("Content")]
        public byte[] Base64Content
        {
            get
            {
                return System.Text.Encoding.UTF8.GetBytes(Content);
            }
            set
            {
                if (value == null)
                {
                    Content = null;
                    return;
                }
                Content = System.Text.Encoding.UTF8.GetString(value);
            }
        }
    }
