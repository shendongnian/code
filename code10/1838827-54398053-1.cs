    public class DetectedLanguage
    {
        public string language { get; set; }
        public double score { get; set; }
    }
    
    public class Translation
    {
        public string text { get; set; }
        public string to { get; set; }
    }
    
    public class RootObject
    {
        public DetectedLanguage detectedLanguage { get; set; }
        public List<Translation> translations { get; set; }
    }
