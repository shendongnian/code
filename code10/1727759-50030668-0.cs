    using System.Threading.Tasks;
    
    namespace Quartz.Api.ScheduledTasks
    {
        public class TestJob : IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                string[] lines = { "First line", "Second line", "Third line" };
                System.IO.File.WriteAllLines(
                    @"C:\Users\GOWDY_N\source\repos\Quartz\Quartz.Api\ScheduledTasks.txt",
                    lines);
                return Task.CompletedTask;
            }
        }
    }
