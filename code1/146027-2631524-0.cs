    catch(Exception ex)
    {
        Exception e = ex;
        StringBuilder message = new StringBuilder();
        while(e != null)
        {
            if(message.Length > 0) message.AppendLine("\nInnerException:");
            message.AppendLine(e.ToString());
            e = e.InnerException;
        }
        EventLogger.LogEvent(EventSource, EventLogType, "OnStart" + _lineFeed +
             message.ToString());
    }
