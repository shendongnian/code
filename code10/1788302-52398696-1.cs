            static void Main(string[] args)
            {
                TelemetryConfiguration.Active.InstrumentationKey = "your key";
                var telemetry = new TelemetryClient();
    
                var parameters = new Dictionary<string, string>();
    
                parameters.Add("Message", "message test");
                parameters.Add("AgentId", "Agent test");
                parameters.Add("ScheduleId", "schedule test");
                parameters.Add("ScheduleStartDate", DateTime.Now.ToString());
    
                var metrics = new Dictionary<string, double>();
                
                    metrics.Add("Duration", 999.99);
    
                telemetry.TrackEvent("Agents event", parameters, metrics);
    
                telemetry.TrackTrace("Agents trace");
    
                telemetry.TrackTrace("message trace", SeverityLevel.Information);
                //telemetry.TrackTrace("0919 after today...");
    
                System.Threading.Thread.Sleep(5000);
                telemetry.Flush();
    
                Console.WriteLine("done now.");
                Console.ReadLine();
            }
    
