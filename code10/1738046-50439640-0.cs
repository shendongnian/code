       [DisallowConcurrentExecution]
        public class MailJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            { 
                // Do Work
                await Console.Out.WriteLineAsync("Mail Job is executing.");
            }
        }
