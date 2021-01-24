    static async Task Execute(Message message, TextWriter log)
    {
        TelemetryClient telemetry = new TelemetryClient();
        telemetry.TrackEvent("WinGame");
        ...
