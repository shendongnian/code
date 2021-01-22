    log4net.ILog log = log4net.LogManager.GetLogger(loggerName);
    log4net.Repository.Hierarchy.Logger logImpl = log.Logger as log4net.Repository.Hierarchy.Logger;
    if (logImpl != null)
        logImpl.AddAppender(uploadLogAppender);
    else {
        // unexpected logger type - handle this case somehow
    }
    ProcessUpload(); // does logging
    if (logImpl != null)
        logImpl.RemoveAppender(uploadLogAppender);
