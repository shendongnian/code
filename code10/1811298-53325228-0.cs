    public partial class Result
        {
            [JsonProperty("status")]
            public string Status { get; set; }
    
            [JsonProperty("succeeded")]
            public bool Succeeded { get; set; }
    
            [JsonProperty("failed")]
            public bool Failed { get; set; }
    
            [JsonProperty("finished")]
            public bool Finished { get; set; }
    
            [JsonProperty("recognitionResult")]
            public RecognitionResult RecognitionResult { get; set; }
        }
    
        public partial class RecognitionResult
        {
            [JsonProperty("lines")]
            public Line[] Lines { get; set; }
        }
    
        public partial class Line
        {
            [JsonProperty("boundingBox")]
            public long[] BoundingBox { get; set; }
    
            [JsonProperty("text")]
            public string Text { get; set; }
    
            [JsonProperty("words")]
            public Word[] Words { get; set; }
        }
    
        public partial class Word
        {
            [JsonProperty("boundingBox")]
            public long[] BoundingBox { get; set; }
    
            [JsonProperty("text")]
            public string Text { get; set; }
        }
