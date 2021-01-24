    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility;
    
    namespace WebApplication1netcore4
    {
        public class MyTelemetryProcessor : ITelemetryProcessor
        {
            private ITelemetryProcessor Next { get; set; }
    
            public MyTelemetryProcessor(ITelemetryProcessor next)
            {
                this.Next = next;
            }
    
            public void Process(ITelemetry telemetry)
            {
    
                TraceTelemetry trace = telemetry as TraceTelemetry;
    
                if (trace != null && trace.Context.Properties.Keys.Contains("CategoryName"))
                {
                    //Here I just filter out 2 kinds of trace messages, you can adjust your code as per your need.
                    if (trace.Context.Properties["CategoryName"] == "Microsoft.AspNetCore.Hosting.Internal.WebHost" || trace.Context.Properties["CategoryName"] == "Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker")
                    {
                        //return means abandon this trace message which has the specified CategoryName
                        return;
                    }
                }
    
                if (trace == null)
                {
                    this.Next.Process(telemetry);
    
                }
    
                if (trace != null)
                {
                    this.Next.Process(trace);
                }
            }
        }
    }
