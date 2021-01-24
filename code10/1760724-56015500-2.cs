    namespace NewProject
    {
     public static class PingTimer
        {
            [FunctionName("PingTimer")]
            public static async Task Run([TimerTrigger("0 */4 * * * *")]TimerInfo myTimer, TraceWriter log)
            {
                // This CRON job executes every 4 minutes
                
    log.Info($"PingTimer function executed at: {DateTime.Now}");
    
                var client = new HttpClient();
                string url = @"<Azure function URL>";
                var result = await client.GetAsync(new Uri(url));
                
                log.Info($"PingTimer function executed completed at: {DateTime.Now}");
            }
        }}
