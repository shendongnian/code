    public class TaskComparer: IComparer<Task>
    {
    	public virtual int Compare(Task t1, Task t2)
    	{
            // second task is included in first task dependencies, it should be considered "bigger" than first
    		if (t1.Dependencies.Contains(t2.Name))
    			return 1;
    			
            // first task is included in second task dependencies, it should be considered "bigger" than second
    		if (t2.Dependencies.Contains(t1.Name))
    			return -1;
    
    		return 0;
    	}
    }
	public static void Main()
    {
        // The following array is an example of specific tasks and dependencies between them.
        // For example the following constructor:
        // new Task("task_a", "task_c")
        // means that task_a may be started only after task_c is complete
        var tasks = new[]
        {
            new Task("task_a", "task_c"),
            new Task("task_b", "task_c"),
            new Task("task_c", "task_e"),
            new Task("task_d", "task_a", "task_e"),
            new Task("task_e"),
        };
		
		var sortedList = tasks.OrderBy(t => t, new TaskComparer()).ToList();
		foreach (Task t in sortedList)
			Console.WriteLine(t.Name);
		
		Console.WriteLine();
		// another set of data
		tasks = new Task[]
		{
			new Task("task_a", "task_b", "task_c"),
			new Task("task_b"),
			new Task("task_c", "task_b"),
		};
		
		sortedList = tasks.OrderBy(t => t, new TaskComparer()).ToList();
		foreach (Task t in sortedList)
			Console.WriteLine(t.Name);
    }
