    [XmlRoot(ElementName = "GSP")]
    public class SearchResult
    {
        [XmlElement(ElementName = "Head")]
        public Head Head { get; set; }
    
        [XmlArray(ElementName = "Results")]
        [XmlArrayItem(ElementName = "Result")]
        public List<ResultItem> mySearchResultItems { get; set; }
    
    
    }
    public class Head
    {
        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }
    }
    
    public class ResultItem
    {
    ...
    }
