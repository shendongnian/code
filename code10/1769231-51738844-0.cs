    public class ReminderJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var parameters = context.JobDetail.JobDataMap;
            var userId = parameters.GetLongValue("UserId");
            var homeWorkId = parameters.GetLongValue("HomeWorkId");
            await System.Console.Out.WriteLineAsync("HelloJob is executing.");
        }
