    public static class TaskExtensions
    	{
    		/// <summary>		
    		/// It is used when you want to call an async method without
    		/// awaiting for it. Using this method suppresses the warning CS4014.
    		/// </summary>
    		/// <param name="task">Task to be called using a fire-and-forget call</param>
    		public static void Forget(this Task task)
    		{
    			task.ConfigureAwait(false);
    		}
    	}
