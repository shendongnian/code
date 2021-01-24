     public class SearchReponse
    {
        public GeneralInfo GeneralInfo { get; set; }
        public ErrorInfo ErrorInfo { get; set; }
        public string Hotels { get; set; }
    }
    public class GeneralInfo
    {
        public string Token { get; set; }
        public long Duration { get; set; }
    }
    public class ErrorInfo
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
