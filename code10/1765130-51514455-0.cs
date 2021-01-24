	[DisallowConcurrentExecution]
	public class MyProcessJob : IJob
	{     
		private readonly Process _process;
		
		public MyProcessJob(Process process)
		{
			_process = process;
		}
	   
		public void Execute(IJobExecutionContext context)
		{
			_process.MainProcess();
		}
	}
