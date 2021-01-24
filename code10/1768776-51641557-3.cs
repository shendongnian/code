    public static async Task RunTasksConcurrently()
	{
		IList<Task> tasks = new List<Task>();
		
		for (int i = 1; i < 4; i++)
		{
			tasks.Add(RunNextTask());
		}
		
		foreach (var task in tasks) {
			await task;	
		}
	}
	
	public static async Task RunNextTask()
	{
		while(true) {
			await Task.Delay(500);
		}
	}
