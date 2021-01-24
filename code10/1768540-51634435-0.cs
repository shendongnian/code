    public class TaskQueue
    {
    	public Queue<Task> CurrentTasks { get; private set; }
    	public bool TaskQueueRunning { get; private set; }
    
    	public TaskQueue()
    	{
    		CurrentTasks = new Queue<Task>();
    		TaskQueueRunning = false;
    	}
    
    	public void AddTask(Task task)
    	{
    		CurrentTasks.Enqueue(task);
    		ProcessTasks();
    	}
    
    	private void ProcessTasks()
    	{
    		if (!TaskQueueRunning)
    		{
    			TaskQueueRunning = true;
    			ProcessIndividualTask();
    		}
    	}
    	private void ProcessIndividualTask()
    	{
    		if (CurrentTasks.Count > 0)
    		{
    			TaskItem currenttask = CurrentTasks.Dequeue();
    			currenttask.CurrentTask.ContinueWith(x => ProcessIndividualTask());
    			currenttask.CurrentTask.Start();
    		}
    		else
    		{
    			TaskQueueRunning = false;
    		}
    	}
    }
