	private async Task CreateToDoAsync()
	{
		List<Task> taskList = new List<Task>();
		for (int i = 1; i < 10; i++)
		{
			var local_i = i;
			var task = Task.Run(() => CreateToDo(local_i));
			Task continuation = task.ContinueWith((antecedent) => Invoke(new AssignTaskDelegate(AssignTask), (new Person()
			{
				Name = $"Person_{local_i}",
				ToDoForPerson = antecedent.Result
			})));
			taskList.Add(task);
		}
		await Task.WhenAll(taskList.ToArray());
	}
