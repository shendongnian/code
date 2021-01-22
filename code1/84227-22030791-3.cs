    string path = null;
    if (LogManager.GetCurrentLoggers().Length > 0 && LogManager.GetCurrentLoggers()[0].Logger.Repository.GetAppenders().Length > 0)
    {
        path = (LogManager.GetCurrentLoggers()[0].Logger.Repository.GetAppenders()[0] as FileAppender).File;
    }
