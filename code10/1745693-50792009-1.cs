    using System;
    using System.Diagnostics;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.ApplicationInsights.TraceListener;
    
    namespace CoreConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                TelemetryConfiguration.Active.InstrumentationKey =
                    "<your ikey>";
    
                Console.WriteLine("Hello World!");
    
                Trace.Listeners.Add(new ApplicationInsightsTraceListener());
                Trace.TraceError("my error");
                Trace.TraceInformation("my information");
    
                TelemetryClient client = new TelemetryClient();
                client.TrackTrace("Demo application starting up.");
    
                Console.ReadKey();
            }
        }
    }
