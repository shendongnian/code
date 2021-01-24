    public class Error
    {
        public string desciption { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public int code { get; set; }
        public int errorsCount { get; set; }
        public List<Error> errors { get; set; }
    }
