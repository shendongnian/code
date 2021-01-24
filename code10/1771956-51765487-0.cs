    public class Config
    {
        public string QDescription { get; set; }
    }
    
    public class Settings
    {
        public string ForceResponse { get; set; }
        public string ForceResponseType { get; set; }
        public string Type { get; set; }
    }
    
    public class Validation
    {
        public Settings Settings { get; set; }
    }
    
    public class Question
    {
        public string DETag { get; set; }
        public Config Config { get; set; }
        public List<string> COrder { get; set; }
        public Validation Validation { get; set; }
    }
    
    public class RootObject
    {
        public List<string> QuestionIDs { get; set; }
        public Dictionary<string, Question> QuestionDefinitions { get; set; }
        public object NextButton { get; set; }
        public bool PreviousButton { get; set; }
    }
