    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
    
    	int taskCount= Settings.Default.TaskCount;
    	int monitorIntervalSeconds = Settings.Default.MonitorInterval;
    	List<Task> taskList = new List<Task>();
    	 while (true)
    	{
    
    		for (int i = 0; i < taskCount; i++)
    			taskList.Add(Task.Factory.StartNew(fn => { TaskHandleSvr.RegisterRun().Wait(); }, null));
    		await Task.Factory.ContinueWhenAll(taskList.ToArray(), wordCountTasks =>
    		 {
    				int count = TaskHandleSvr.ProcessMisseHandledRedisMsg().Result;                   
    				string sLogTime = $"{DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss.ffff")}";
    				string sLogName = "--myTaskGroup--";
    				string sLogMessage = "Task End";
    				NLogHelper.Info($"{sLogName}*|*{sLogTime}*|*RollBack {count} Message");
    				NLogHelper.Info($"{sLogName}*|*{sLogTime}*|*{sLogMessage}");
    		});
    
    		 //Release Resource
    		foreach (var item in taskList)
    			item.Dispose();
    		taskList.RemoveRange(0, taskList.Count);
    
    		await Task.Delay(TimeSpan.FromSeconds(monitorIntervalSeconds), cancellationToken);
    	}
    }
