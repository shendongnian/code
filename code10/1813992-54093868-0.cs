    Equery = (from eventLog in context.EventLogs.AsEnumerable()
                      where eventLog.TaskID == IntEid && eventLog.ResultCode != 0 && eventLog.EventType == 2
                      select new EventLog()
                      {
                          TaskID = eventLog.TaskID,
                          EventDesc = eventLog.EventDesc,
                          ResultCode = eventLog.ResultCode,
                          TaskInstanceID = eventLog.TaskInstanceID
                      }).ToList();
