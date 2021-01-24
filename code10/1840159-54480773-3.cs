        namespace FunctionApp10
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([EventGridTrigger]Microsoft.Azure.EventGrid.Models.EventGridEvent eventGridEvent, TraceWriter log)
            {
                log.Info(eventGridEvent.Data.ToString());
            }
        }
    }
