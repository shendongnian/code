    [DataContract]
    public class GoogleSearchResults
    {
        [DataMember]
        public ResponseData responseData { get; set; }
    }
    [DataContract]
    public class ResponseData
    {
        [DataMember]
        public IEnumerable<Results> results { get; set; }
    }
    [DataContract]
    public class Results
    {
        [DataMember]
        public string unescapedUrl { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string visibleUrl { get; set; }
        [DataMember]
        public string cacheUrl { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string titleNoFormatting { get; set; }
        [DataMember]
        public string content { get; set; }
    }
