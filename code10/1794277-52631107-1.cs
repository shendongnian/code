    class Program
    {
    	static void Main(string[] args)
    	{			
    		mStopWatch.Start();
    		Task[] awaitTasks = mTasks.Select(aTask => Task.Run(() => aTask.TimeConsumingTask())).ToArray();
    		Task.WaitAll(awaitTasks);
    		Debug.WriteLine("Done @ " + mStopWatch.Elapsed.ToString());
    	}
    	static Stopwatch mStopWatch = new Stopwatch();
    	static ProviderOfLengthyTask[] mTasks = new ProviderOfLengthyTask[]
    	{
    		new ProviderOfLengthyTask("A"),
    		new ProviderOfLengthyTask("B"),
    		new ProviderOfLengthyTask("C"),
    		new ProviderOfLengthyTask("D")
    	};
    	class ProviderOfLengthyTask
    	{
    		public ProviderOfLengthyTask(string name)
    		{
    			Name = name;
    		}
    		public readonly string Name;
    		public void TimeConsumingTask()
    		{
    			Thread.Sleep(1000);
    			Debug.WriteLine("Done with " + Name + " @ " + mStopWatch.Elapsed.ToString());
    		}
    	}
    }
