    TelemetryConfiguration tcConfig = new TelemetryConfiguration();
    
    TelemetryClient tc = new TelemetryClient(tcConfig)
    {
        InstrumentationKey = ikey
    };
