    public static LogEntry Authenticate(....)
            {
                LogEntry logEntry = null;
                try
                {
                    ....
                    return logEntry;
                }
    
                catch (CompanyException)
                {
                    throw;
                }
    
                catch (Exception ex)
                {
                    logEntry = new LogEntry(
                        "5006",
                        RC.GetString("5006"), EventLogEntryType.Error,
                        LogEntryCategory.Foo);
    
                    throw new CompanyException(logEntry, ex);
                }
            }
