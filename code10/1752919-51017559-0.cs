    public class ExceptionDetail
    {
        public string Message { get; set; }
    
        public string InnerExceptionMessage { get; set; }
    
        public string StackTrace { get; set; }
    
        public IEnumerable<string> StackTraceLines { get; set; }
    
        public string Target { get; set; }
    
        public string Source { get; set; }
    }
    var exDetail = new ExceptionDetail
    {
        Message = exception.Message,
        InnerExceptionMessage = exception.InnerException?.Message,
        Source = exception.Source,
        StackTrace = exception.StackTrace,
        StackTraceLines = exception.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList(),
        Target = exception.TargetSite.ToString()
    };
