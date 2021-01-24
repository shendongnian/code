        var responseAsJObject = JObject.Parse(exceptionBody);
        var properties = new Dictionary<string, string>();
        foreach (var pair in responseAsJObject)
        {
            properties.Add(pair.Key, pair.Value.ToString());
        }
        var measurements = new Dictionary<string, double>();
        var hasFullStack = properties.TryGetValue("StackTrace", out var stack);
         var edi = new ExceptionDetailsInfo
        (
            10000,
            10000,
            properties["ExceptionType"],
            $"{properties["Message"]} {url}",
            hasFullStack,
            stack ?? string.Empty,
            new List<StackFrame>()
        );
        var exceptionTelemetry = new ExceptionTelemetry
        (
            new List<ExceptionDetailsInfo>{edi},
            SeverityLevel.Error,
            $"HTTP Error {statusCode}",
            properties,
            measurements
        );
        telemetryClient.TrackException(exceptionTelemetry);
