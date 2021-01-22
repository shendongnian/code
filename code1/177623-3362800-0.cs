            ITaskService scheduler = new TaskSchedulerClass();
            scheduler.Connect(null, null, null, null);
            ITaskFolder rootFolder = scheduler.GetFolder("\\");
            ITaskFolder folder = rootFolder.GetFolders(0).Cast<ITaskFolder>().FirstOrDefault(f => f.Name == "Windows7Course");
            if (folder == null)
            {
                folder = rootFolder.CreateFolder("Windows7Course", null);
            }
            ITaskDefinition task = scheduler.NewTask(0);
            IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
            action.Path = typeof(SayHello.Form1).Assembly.Location;
            action.WorkingDirectory = Path.GetDirectoryName(typeof(SayHello.Form1).Assembly.Location);
            ISessionStateChangeTrigger trigger = (ISessionStateChangeTrigger)task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_SESSION_STATE_CHANGE);
            trigger.StateChange = _TASK_SESSION_STATE_CHANGE_TYPE.TASK_SESSION_UNLOCK;
            task.Settings.DisallowStartIfOnBatteries = true;
            task.RegistrationInfo.Author = "Kate Gregory";
            task.RegistrationInfo.Description = "Launches a greeting.";
            IRegisteredTask ticket = folder.RegisterTaskDefinition("GreetReturningUser", task, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN, null);
