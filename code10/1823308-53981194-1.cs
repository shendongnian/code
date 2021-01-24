    public class SharePointDocumentItems
    {
        public class Value
        {
            [JsonProperty("@odata.etag")]
            public string OdataEtag { get; set; }
            
            public string ETag { get; set; }
            public string Id { get; set; }
            public string WebUrl { get; set; }
        }
    
        public class RootObject
        {
            [JsonProperty("@odata.context")]
            public string OdataContext { get; set; }
    
            public List<Value> value { get; set; }
        }
    }
