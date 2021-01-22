    public IList<ITraceLogRecord> GetTraceLogRecords(string systemType, string plantName, int? deviceId, DateTime startTime, DateTime endTime, string logDescription, string loggerName, List<int> traceLevelIds)
        {
            IDictionary<string, object> traceQueryParameters = new Dictionary<string, object>();
            traceQueryParameters.Add("deviceId", deviceId);
            traceQueryParameters.Add("startTime", startTime);
            traceQueryParameters.Add("endTime", endTime);
            traceQueryParameters.Add("logDescription", logDescription);
            traceQueryParameters.Add("loggerName", loggerName);
            traceQueryParameters.Add("traceLevelIds", traceLevelIds);
            return DataSources.GetDbConnectionName(systemType, plantName).QueryForList<ITraceLogRecord>("SelectTraceLogRecords", traceQueryParameters);
        }
