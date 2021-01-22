    catch (Exception ex)
    {
      logEntry = new LogEntry("5006",
                        RC.GetString("5006"), EventLogEntryType.Error,
                        LogEntryCategory.Foo);
      ex.Data.Add("5006",logEntry);
      throw;
    }
