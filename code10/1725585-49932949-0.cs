    private async Task<bool> StringSetTrackedAsync(RedisKey key, string value)
    {
        var dependency = new DependencyTelemetry()
        {
            Type = "Redis",
            Name = "SetStringAsync"
        };
        dependency.Properties["key"] = key;
        using (telemetryClient.StartOperation(dependency))
        {
            var result = await cache.StringSetAsync(key, value);
            dependency.Success = result;
            return result;
        }
    }
    
