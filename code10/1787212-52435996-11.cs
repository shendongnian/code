    public class RetryTempJob : IJob {
        private readonly ILogger logger;
        
        public RetryTempJob(ILogger logger) {
            this.logger = logger;
        }
        public async Task Execute(IJobExecutionContext context) {
            try {
                logger.log("Executing Job");
                new ProcessOrder().retryFailedOrders();
                //logger.log("Done Executing Syspro Job");
                await Console.Error.WriteLineAsync("Done Executing Syspro Job");
            } catch (Exception se) {
                await Console.Error.WriteLineAsync("" + se.InnerException);
            }
        }
    }
    
