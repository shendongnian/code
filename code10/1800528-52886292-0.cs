    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.Extensibility;
    
    namespace WebApplicationWebApi
    {
        public class ExceptionsFilter:ITelemetryProcessor
        {
            private ITelemetryProcessor Next { get; set; }
            public ExceptionsFilter(ITelemetryProcessor next)
            {
                this.Next = next;
            }
    
            public void Process(ITelemetry item)
            {
                string s = item.GetType().Name;
    
                //if it's not exception telemetry, just return without log it to app insights.
                if (s != "ExceptionTelemetry")
                {
                    return;
                }            
    
                this.Next.Process(item);
            }
            
        }
    }
