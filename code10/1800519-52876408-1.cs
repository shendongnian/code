    var telemetryMock = new Mock<ITelemetryClientWrapper>();
    var target = new MyLogger(telemetryMock.Object);
    target.Log(...);
    
    telemetryMock.Verify(c => c.TrackEvent());
