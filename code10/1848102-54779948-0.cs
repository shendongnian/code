    public ValueController(TelemetryClient telemetryClient)
    {
        this.telemetryClient = telemetryClient;
        var props = this.telemetryClient.Context.GlobalProperties;
                foreach (var p in props)
                {
                    if (p.Key.Contains("param"))
                    {
                        props.Remove(p.Key);
                    }
                }
    }
