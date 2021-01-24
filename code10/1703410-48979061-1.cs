    public class WinLogEvent
    {
        public string ComputerName { get; set; }
        public string LogName { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public UInt16 EventCode { get; set; }
        public uint EventIdentifier { get; set; }
        public string EventType { get; set; }
        public uint RecordNumber { get; set; }
        public DateTime TimeGenerated { get; set; }
        public DateTime TimeLogged { get; set; }
        public byte[] Data { get; set; }
        public string[] InsertionStrings { get; set; }
    }
        public List<WinLogEvent> BackupEventLogFilterBySource(String logName, String sourceName)
        {
            List<WinLogEvent> LogEvents = new List<WinLogEvent>();
            ConnectionOptions _ConnOptions = new ConnectionOptions();
            _ConnOptions.EnablePrivileges = true;
            _ConnOptions.Timeout = EnumerationOptions.InfiniteTimeout;
            _ConnOptions.Authentication = AuthenticationLevel.Default;
            _ConnOptions.Impersonation = ImpersonationLevel.Impersonate;
            //Add (if needed) => .UserName, .Password, .Authority 
            
            ManagementScope _Scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\CIMV2", _ConnOptions);
            _Scope.Connect();
            SelectQuery _Query = new SelectQuery("SELECT * FROM Win32_NTLogEvent");
            _Query.Condition = string.Format("Logfile='{0}' AND SourceName LIKE '%{1}%'", logName, sourceName);
            EnumerationOptions _Options = new EnumerationOptions();
            _Options.Rewindable = true;
            _Options.ReturnImmediately = true;
            using (ManagementObjectSearcher search = new ManagementObjectSearcher(_Scope, _Query, _Options))
            {
                foreach (ManagementObject _EventLog in search.Get())
                {
                    LogEvents.Add(new WinLogEvent { 
                               ComputerName = _EventLog.GetPropertyValue("ComputerName").ToString(),
                               LogName = _EventLog.GetPropertyValue("Logfile").ToString(),
                               Source = _EventLog.GetPropertyValue("SourceName").ToString(),
                               EventCode = (UInt16)_EventLog.GetPropertyValue("EventCode"),
                               EventIdentifier = (uint)_EventLog.GetPropertyValue("EventIdentifier"),
                               EventType = _EventLog.GetPropertyValue("Type").ToString(),
                               RecordNumber = (uint)_EventLog.GetPropertyValue("RecordNumber"),
                               TimeGenerated = ManagementDateTimeConverter.ToDateTime(_EventLog.GetPropertyValue("TimeGenerated").ToString()),
                               TimeLogged = ManagementDateTimeConverter.ToDateTime(_EventLog.GetPropertyValue("TimeWritten").ToString()),
                               Message = _EventLog.GetPropertyValue("Message").ToString() ?? string.Empty,
                               InsertionStrings = (string[])_EventLog.GetPropertyValue("InsertionStrings"),
                               Data = (byte[])_EventLog.GetPropertyValue("Data"),
                    });
                }
            }
            return LogEvents;
        }
