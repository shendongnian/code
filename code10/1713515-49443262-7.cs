    string jsonData;
    using (LogContext.PushProperty("property1", "SomeValue"))
    using (LogContext.PushProperty("property2", 123))
    {
    	var dump = LogContextSerializer.Serialize();
    	jsonData = JsonConvert.SerializeObject(dump);
    }
    
    //	Pass jsonData between processes
    
    var restoredDump = JsonConvert.DeserializeObject<LogContextDump>(jsonData);
    using (LogContextSerializer.Deserialize(restoredDump))
    {
    	//  LogContext is the same as when Clone() was called above
    }
