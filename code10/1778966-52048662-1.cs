    ...
    [HttpGet("{queryMonitorId}/{subjectId}", Name = "Get")]
    public async Task<IActionResult> GetMonitor(string queryMonitorId, string subjectId)
    {
        ...
        // Your get implementation here.
        Ok(new MonitorDto { QueryMonitorId = queryMonitorId, SubjectId = subjectId });
    }
