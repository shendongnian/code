    public StringBuilder GetLogMessage(LogEventType logType, object message)
    {
            StringBuilder logEntry = new StringBuilder();
            logEntry.AppendFormat("DATE={0} ", DateTime.Now.ToString("dd-MMM-yyyy", new CultureInfo(CommonConfig.EnglishCultureCode)));
            logEntry.AppendFormat("TIME={0} ", DateTime.Now.ToString("HH:mm:ss", new CultureInfo(CommonConfig.EnglishCultureCode)));
            logEntry.AppendFormat("ERRORNO={0} ", base.RemoteIPAddress.ToString().Replace(".", string.Empty));
            logEntry.AppendFormat("IP={0}", base.RemoteIPAddress.ToString());
            logEntry.AppendFormat("LANG={0} ", base.Culture.TwoLetterISOLanguageName);
            logEntry.AppendFormat("PNR={0} ", this.RecordLocator);
            logEntry.AppendFormat("AGENT={0} ", base.UserAgent);
            logEntry.AppendFormat("REF={0} ", base.Referrer);
            logEntry.AppendFormat("SID={0} ", base.CurrentContext.Session.SessionID);
            logEntry.AppendFormat("LOGTYPE={0} ", logType.ToString() );
            var module_log = GetModuleLog();        
            logEntry.AppendFormat("MODULE={0}", (!String.IsNullOrEmpty(module_log))
                         ?module_log
                         :String.Empty);
            logEntry.AppendFormat("MESSAGE={0} ", message);
            return logEntry;
    }
    
    protected virtual string GetModuleLog(){
     // code in the derived class to return the log related to the module...
    }
