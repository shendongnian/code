        namespace FunctionApp7
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([EventGridTrigger]JObject eventGridEvent, TraceWriter log)
            {
                log.Info(eventGridEvent.ToString(Formatting.Indented));
            }
        }
    }
