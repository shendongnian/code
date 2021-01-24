    //I enhance the Log4Net logging by capturing the caller's name and the line of code number
    public static void Error(Type source, object message, Exception e = null, [CallerMemberName] string memberName = "",
     [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
    	ILog logger = getLogger(source);
    	if (!logger.IsErrorEnabled) return;
    
    	if (e == null)
    		logger.Error(string.Format("MemberName: {0}, SourceLineNumber of {1}, Message: {2}", memberName, sourceLineNumber, message));
    	else
    		logger.Error(string.Format("MemberName: {0}, SourceLineNumber of {1}, Message: {2}", memberName, sourceLineNumber, message), e);
    
    }
