	public delegate void TaskAssigner(User user, bool taskFlag)
	
	IDictionary<string, TaskAssigner> taskAssigners = new Dictionary<string, TaskAssigner>();
		
	...
	
	taskAssigners.Add(ClassStructure.Tasks_CallIDs_Strings.TASK1, (u, t) => u.TASK1 = t;);
	taskAssigners.Add(ClassStructure.Tasks_CallIDs_Strings.TASK2, (u, t) => u.TASK2 = t;);
	
	...
	
	foreach(ClassStructure.Tasks data in TaskStatus)
		taskAssigners[data.Task_Call_ID](user, data.Task_Flag);
