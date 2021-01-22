    string GetUser(string path) {
        object nowDate = Now;
        GetUser = "Unknown";
        Threading.Thread.Sleep(1000);
        // # Search user in the security event log
        object secLog = new EventLog("Security", EVENTLOGSERVER);
        EventLogEntry entry;
        for (int i = (secLog.Entries.Count - 1); (i <= Math.Max((secLog.Entries.Count - 1500), 0)); i = (i + -1)) {
            entry = secLog.Entries(i);
            if (IsValidEntry(path, nowDate, entry)) {
                GetUser = entry.ReplacementStrings(11);
                break;
            }
        }
    }
    
    bool IsValidEntry(string path, DateTime nowDate, EventLogEntry entry) {
        return ((entry.EntryType == EventLogEntryType.SuccessAudit) 
            && ((entry.InstanceId == 560) || (entry.InstanceId == 564)) 
            && !entry.UserName.EndsWith("SYSTEM")
            && (Math.Abs(nowDate.Subtract(entry.TimeGenerated).TotalSeconds <= 20) 
            && (entry.ReplacementStrings.GetUpperBound(0) >= 11) 
            && (entry.ReplacementStrings(2).Length >= 4) 
            && path.EndsWith(entry.ReplacementStrings(2).Substring(4)));
    }
