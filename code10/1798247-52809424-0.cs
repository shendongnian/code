    public static class SerilogWithCallerAttributes
    {
        public static void Main()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();
    
            GoDoSomething();
        }
    
        public static void GoDoSomething()
        {
            int score = 12;
    
            Log.Information("Player scored: {Score}", CallerInfo.Create(), score);
        }
    }
    
    public static class Log
    {
        public static void Information(string messageTemplate, CallerInfo callerInfo, params object[] propertyValues)
        {
            Serilog.Log.Logger
                .ForHere(callerInfo.CallerFilePath, callerInfo.CallerMemberName, callerInfo.CallerLineNumber)
                .Information(messageTemplate, propertyValues);
        }
    }
    
    public static class LoggerExtensions
    {
        public static ILogger ForHere(
            this ILogger logger,
            [CallerFilePath] string callerFilePath = null,
            [CallerMemberName] string callerMemberName = null,
            [CallerLineNumber] int callerLineNumber = 0)
        {
            return logger
                .ForContext("SourceFile", callerFilePath)
                .ForContext("SourceMember", callerMemberName)
                .ForContext("SourceLine", callerLineNumber);
        }
    }
    
    public class CallerInfo
    {
        public string CallerFilePath { get; private set; }
    
        public string CallerMemberName { get; private set; }
    
        public int CallerLineNumber { get; private set; }
    
        private CallerInfo(string callerFilePath, string callerMemberName, int callerLineNumber)
        {
            this.CallerFilePath = callerFilePath;
            this.CallerMemberName = callerMemberName;
            this.CallerLineNumber = callerLineNumber;
        }
    
        public static CallerInfo Create(
            [CallerFilePath] string callerFilePath = null,
            [CallerMemberName] string callerMemberName = null,
            [CallerLineNumber] int callerLineNumber = 0)
        {
            return new CallerInfo(callerFilePath, callerMemberName, callerLineNumber);
        }
    }
