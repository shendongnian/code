    public class TranslationResponseData
    {
        public string translatedText { get; set; }
    }
    
    public class TranslationReturnObject
    {
        public TranslationResponseData repsonseData { get; set;}
        public string responseDetails { get; set; }
        public string responseStatus { get; set; }  
    }
