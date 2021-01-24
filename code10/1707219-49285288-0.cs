    public class RequestTelemetryInitializer : ITelemetryInitializer
	{
		public void Initialize(ITelemetry telemetry)
		{
			if (telemetry is RequestTelemetry requestTelemetry)
				RequestVariables.RequestTelemetry.Value = requestTelemetry;
		}
	}
    
