    public void CreateTaskScheduler()
    {
        var file = $"{Setting.GetDirectory()}\\{Setting.GetSpacename()}.exe";
        TaskService ts = new TaskService();
        TaskDefinition td = ts.NewTask();
        Trigger trigger = new DailyTrigger();
        trigger.Repetition.Interval = TimeSpan.FromMinutes(5);
        td.Triggers.Add(trigger);
        td.Actions.Add(new ExecAction(file, null, null));
        ts.RootFolder.RegisterTaskDefinition(TaskName, td);
    }
