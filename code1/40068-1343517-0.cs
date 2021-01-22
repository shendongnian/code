    public class LogCategory
    {
     private LogCategory(string value) { Value = value; }
    
     public string Value { get; set; }
    
     public static LogCategory Trace { get { return new LogCategory("Trace"); } }
     public static LogCategory Debug { get { return new LogCategory("Debug"); } }
     public static LogCategory Info { get { return new LogCategory("Info"); } }
     public static LogCategory Warning { get { return new LogCategory("Warning"); } }
     public static LogCategory Error { get { return new LogCategory("Error"); } }
    }
