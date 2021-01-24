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
        public DateTime? TimeGenerated { get; set; }
        public DateTime? TimeLogged { get; set; }
        public byte[] Data { get; set; }
        public string[] InsertionStrings { get; set; }
    }
    private static EnumerationOptions GetEnumerationOptions(bool deepScan)
    {
        var mOptions = new EnumerationOptions()
        {
            Rewindable = false,        //Forward only query => no caching
            ReturnImmediately = true,  //Pseudo-async result
            DirectRead = true,
            EnumerateDeep = deepScan
        };
        return mOptions;
    }
    private static ConnectionOptions GetConnectionOptions(string UserName, string Password, string Domain)
    {
        var connOptions = new ConnectionOptions()
        {
            EnablePrivileges = true,
            Timeout = ManagementOptions.InfiniteTimeout,
            Authentication = AuthenticationLevel.PacketPrivacy,
            Impersonation = ImpersonationLevel.Default,
            Username = UserName,
            Password = Password,
            //Authority = "NTLMDOMAIN:[domain]"
            Authority = !string.IsNullOrEmpty(Domain) ? $"NTLMDOMAIN:{Domain}" : string.Empty
        };
        return connOptions;
    }
    public static List<WinLogEvent> BackupEventLogFilterBySource(string logName, string sourceName)
    {
        List<WinLogEvent> logEvents = new List<WinLogEvent>();
        var connOptions = GetConnectionOptions(null, null, null);
        var options = GetEnumerationOptions(false);
        var scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\CIMV2", connOptions);
        scope.Connect();
        var query = new SelectQuery("SELECT * FROM Win32_NTLogEvent");
        query.Condition = $"Logfile='{logName}' AND SourceName LIKE '%{sourceName}%'";
        using (ManagementObjectSearcher moSearch = new ManagementObjectSearcher(scope, query, options))
        {
            foreach (ManagementObject eventLog in moSearch.Get())
            {
                ManagementBaseObject inParams = eventLog.GetMethodParameters("BackupEventlog");
                inParams["ArchiveFileName"] = @"D:\exp.evtx";
                ManagementBaseObject outParams = eventLog.InvokeMethod("BackupEventLog", inParams, null);
                var res = outParams.Properties["ReturnValue"].Value;
                logEvents.Add(new WinLogEvent
                {
                    ComputerName = eventLog.GetPropertyValue("ComputerName")?.ToString(),
                    LogName = eventLog.GetPropertyValue("Logfile")?.ToString(),
                    Source = eventLog.GetPropertyValue("SourceName")?.ToString(),
                    EventCode = (UInt16?)eventLog.GetPropertyValue("EventCode") ?? 0,
                    EventIdentifier = (uint?)eventLog.GetPropertyValue("EventIdentifier") ?? 0,
                    EventType = eventLog.GetPropertyValue("Type")?.ToString(),
                    RecordNumber = (uint?)eventLog.GetPropertyValue("RecordNumber") ?? 0,
                    TimeGenerated = ManagementDateTimeConverter.ToDateTime(eventLog.GetPropertyValue("TimeGenerated")?.ToString()),
                    TimeLogged = ManagementDateTimeConverter.ToDateTime(eventLog.GetPropertyValue("TimeWritten")?.ToString()),
                    Message = eventLog.GetPropertyValue("Message")?.ToString(),
                    InsertionStrings = (string[])eventLog.GetPropertyValue("InsertionStrings") ?? null,
                    Data = (byte[])eventLog.GetPropertyValue("Data") ?? null,
                });
                inParams.Dispose();
                outParams.Dispose();
            }
        }
        return logEvents;
    }   //BackupEventLogFilterBySource
