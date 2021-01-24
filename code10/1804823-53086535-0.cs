    JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
    dynamic m = new System.Dynamic.ExpandoObject();
    m.SessionId = _sessionId;
    m.ProcessId = _processId.ToString();
    m.ProcessName = _processName;
    m.MachineName = _machineName;
    m.UserName = _userName;
    m.Level = loggingEvent.Level.DisplayName;
    m.Domain = loggingEvent.Domain;
    m.TimeStamp = loggingEvent.TimeStamp.ToString("yyyyMMddHHmmssfff");
    m.MessageObject = loggingEvent.MessageObject;
    if (loggingEvent.ExceptionObject != null)
    {
      m.Exception = loggingEvent.ExceptionObject.ToString();
      m.StackTrace = loggingEvent.ExceptionObject.StackTrace;
    }
    //Convert the object to a json string
    string msg = JsonConvert.SerializeObject(m, Formatting.None, _jsonSerializerSettings);
