        [FunctionName("PingTimer")]
        public static async Task Run([TimerTrigger("0 */4 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            // This CRON job executes every 4 minutes
            
