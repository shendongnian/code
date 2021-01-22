C#
using (TaskService service = new TaskService())
{
	if (!service.RootFolder.AllTasks.Any(t => t.Name == "YourScheduledTaskName"))
	{
		Console.WriteLine("YourScheduledTaskName is not installed on this system. Do you want to install it now? (y/n)");
		var answer = Console.ReadLine();
		if (answer == "y")
		{
			var task = service.NewTask();
			task.RegistrationInfo.Description = "YourScheduledTaskDescription";
			task.RegistrationInfo.Author = "YourAuthorName";
			var hourlyTrigger = new DailyTrigger { StartBoundary = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0 , 0) };
			hourlyTrigger.Repetition.Interval = TimeSpan.FromHours(1);
			task.Triggers.Add(hourlyTrigger);
            var taskExecutablePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "YourScheduledTaskName.exe");
			task.Actions.Add(new ExecAction(taskExecutablePath));
			service.RootFolder.RegisterTaskDefinition("YourScheduledTaskName", task);
		}
	}
}
