    public static class NLogManager {
     
     public static ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
     
     public static void InfoLog(NLogData nLogData) {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Info, NLogManager._logger.Name, nLogData.Message);
      SetLogEventInfo(theEvent, nLogData);
      _logger.Log(theEvent);
     }
     
     
     public static void DebugLog(NLogData nLogData) {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Debug, NLogManager._logger.Name, nLogData.Message);
      SetLogEventInfo(theEvent, nLogData);
      _logger.Log(theEvent);
     }
     
     
     public static void ErrorLog(NLogData nLogData) {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Error, NLogManager._logger.Name, nLogData.Message);
      SetLogEventInfo(theEvent, nLogData);
      _logger.Log(theEvent);
     }
    }
