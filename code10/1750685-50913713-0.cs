    [XmlRoot("book")]
    public class MyBook
    {
        [XmlElement("bookid")]
        public string BookId { get; set; }
        [XmlElement("updatedate")]
        public DateTime UpdateDate { get; set; }
    }
