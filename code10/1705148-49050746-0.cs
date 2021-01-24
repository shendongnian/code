    Dictionary<string, BaseClass> MyTypes;
    public class BaseClass
    {
        public string Reference {get; set;}
        public int Id {get; set;}
        public Dictionary<string, string> Members {get; set;}
    }
    public class SpecialClass : BaseClass
    {
        // you can add an instance of this class to your dictionary too!
    }
