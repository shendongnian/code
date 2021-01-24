    public class WordDefinition
    {
        public List<object> textProns { get; set; }
        public string sourceDictionary { get; set; }
        public List<object> exampleUses { get; set; }
        public List<object> relatedWords { get; set; }
        public List<Label> labels { get; set; }
        public List<object> citations { get; set; }
        public string word { get; set; }
        public string attributionUrl { get; set; }
        public string attributionText { get; set; }
        public string partOfSpeech { get; set; }
        public string text { get; set; }
        public double score { get; set; }
    }
    public class Label
    {
        public string type { get; set; }
        public string text { get; set; }
    }
