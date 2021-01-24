    public static class TaskExtension<T>
    {
      public static async Task<T> FirstSuccess(IEnumerable<Task<T>> tasks, T goodResult)
    	
    	{
    		// Create a List<Task<T>>
    		var taskList = new List<Task<T>>(tasks);
    		// Placeholder for the First Completed Task
    		Task<T> firstCompleted = default(Task<T>);
    		// Looping till the Tasks are available in the List
    		while (taskList.Count > 0)
    		{
    			// Fetch first completed Task
    			var currentCompleted = await Task.WhenAny(taskList);
    			
    			// Compare Condition
    			if (currentCompleted.Status == TaskStatus.RanToCompletion
    			    && currentCompleted.Result.Equals(goodResult))
    			{
    				// Assign Task and Clear List
    				firstCompleted = currentCompleted;
    				taskList.Clear();
    			}
    			else
    			   // Remove the Current Task
    			   taskList.Remove(currentCompleted);
    		}
    		return (firstCompleted != default(Task<T>)) ? firstCompleted.Result : default(T);
    	}
    }
