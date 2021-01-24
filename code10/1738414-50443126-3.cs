        			public static bool InitalizeScheduledTask() {
    string TaskName=//TaskName here;
        				XNamespace taskNamespace =
        					XNamespace.Get("http://schemas.microsoft.com/windows/2004/02/mit/task");
        				XElement taskContents = new XElement(taskNamespace + "Task", new XAttribute("version", "1.4"),
        					new XElement(taskNamespace + "RegistrationInfo",
        						new XElement(taskNamespace + "Date", DateTimeToWin32Format(DateTime.Now)),
        						new XElement(taskNamespace + "Author", WindowsIdentity.GetCurrent().Name),
        						new XElement(taskNamespace + "Description",
        							"[Description here] "),
        						new XElement(taskNamespace + "URI", $"\\{TaskName}")),
        					new XElement(taskNamespace + "Triggers",
        						new XElement(taskNamespace + "LogonTrigger", new XElement(taskNamespace + "Enabled", true))),
        					new XElement(taskNamespace + "Principals",
        						new XElement(taskNamespace + "Principal", new XAttribute("id", "Author"),
        							new XElement(taskNamespace + "GroupId", "S-1-5-32-545"),
        							new XElement(taskNamespace + "RunLevel", "HighestAvailable"))),
        					new XElement(taskNamespace + "Settings",
        						new XElement(taskNamespace + "MultipleInstancesPolicy", "Parallel"),
        						new XElement(taskNamespace + "DisallowStartIfOnBatteries", false),
        						new XElement(taskNamespace + "StopIfGoingOnBatteries", false),
        						new XElement(taskNamespace + "AllowHardTerminate", false),
        						new XElement(taskNamespace + "StartWhenAvailable", false),
        						new XElement(taskNamespace + "RunOnlyIfNetworkAvailable", false),
        						new XElement(taskNamespace + "IdleSettings", new XElement(taskNamespace + "StopOnIdleEnd", true),
        							new XElement(taskNamespace + "RestartOnIdle", false)),
        						new XElement(taskNamespace + "AllowStartOnDemand", true),
        						new XElement(taskNamespace + "Enabled", true), new XElement(taskNamespace + "Hidden", false),
        						new XElement(taskNamespace + "RunOnlyIfIdle", false),
        						new XElement(taskNamespace + "DisallowStartOnRemoteAppSession", false),
        						new XElement(taskNamespace + "UseUnifiedSchedulingEngine", true),
        						new XElement(taskNamespace + "WakeToRun", false),
        						new XElement(taskNamespace + "ExecutionTimeLimit", "PT0S"),
        						new XElement(taskNamespace + "Priority", 7)),
        					new XElement(taskNamespace + "Actions", new XAttribute("Context", "Author"),
        						new XElement(taskNamespace + "Exec",
        							new XElement(taskNamespace + "Command", Process.GetCurrentProcess().MainModule.FileName),
        							new XElement(taskNamespace + "Arguments",//Arguments ))));
        				string taskString = new XDocument(new XDeclaration("1.0", "UTF-16", null),
        					taskContents).ToString();
      				string tempLocation = Path.Combine(Path.GetTempPath(),$"{TaskName}.xml");
        				File.WriteAllText(tempLocation, taskString);
    /*Run Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "SCHTASKS.exe") with the arguments $"/Create /XML \"{tempLocation}\" /TN {TaskName} /RP * /RU {Environment.UserName}"
    I have no time to add that now, in that window you will need to enter your password and you have to be admin*/} 
        public static string DateTimeToWin32Format(DateTime toConvert) =>
        			$"{toConvert.Year:0000}-{toConvert.Month:00}-{toConvert.Day:00}T{toConvert.Hour:00}:{toConvert.Minute:00}:{toConvert.Second:00}.{toConvert.Millisecond:000}0000";
        
        
