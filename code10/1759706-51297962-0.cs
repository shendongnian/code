    [DisallowConcurrentExecution]
	public class CaptureFeedFeedbackLoop : IJob
	{
		public static HumanAnalysisService Has;
		
		public Task Execute(IJobExecutionContext context)
		{
			//Do stuff
			return Task.CompletedTask;
		}
	}
