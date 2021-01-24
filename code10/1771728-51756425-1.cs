    public class Error
    {
        public int Code { get; set; }
        public ErrorMessage[] Msg { get; set; }
    }
    public class ErrorMessage
    {
        public string Message { get; set; }
        public int? Code { get; set; }
    }
