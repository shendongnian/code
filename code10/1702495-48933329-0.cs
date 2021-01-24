    // Get raw Storage object
    [HttpGet]
    public IActionResult GetStorageView(string q)
    {   
        // TODO: do not use in production
        WSManModule.HyperVMetric.test(false);
        //
        var response = MetricsService.Instance.GetRawMetrics();
        if (response == null)
        {
            return NotFound();
        }
        if (q == "quick")
        {
            return Ok(new StorageQuickView(response));
        }
        return Ok(response);
    }
    // Get metrics for specific device
    [HttpGet("{deviceName}")]
    public IActionResult GetDeviceView(string deviceName, string q)
    {
        var response = MetricsService.Instance.GetDeviceMetrics(deviceName);
        if (response == null)
        {
            return NotFound();
        }
        if (q == "quick")
        {
            return Ok(new DeviceQuickView(response));
        }
        return Ok(response);
    }
