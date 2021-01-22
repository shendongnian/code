       private void WriteEventLogToFile()
        {
            try
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                 // source for your event 
                    eventLog.Source = "IAStorDataMgrSvc";
                 
                 // Syntax details
                // eventLog.WriteEntry("details",type of event,event id);
                 eventLog.WriteEntry("Hard disk Failure details", EventLogEntryType.Information, 11);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
