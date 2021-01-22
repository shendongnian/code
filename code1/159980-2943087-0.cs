    [XmlRoot("reviews")]
    public class ReviewListViewData
    {
        [XmlElement("review")]
        public ReviewViewData[] Reviews { get; set; }
    }
