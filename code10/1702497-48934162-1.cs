    // Get metrics for specific component within the device
    [HttpGet("{deviceName}/{componentName}")]
    public IActionResult GetComponentView(string deviceName, string componentName)
    {
        var response = MetricsService.Instance.GetComponentMetrics(deviceName, componentName);
    
        return ProcessResponse<ComponentQuickView>(response);
    }
    // Get raw Storage object
    [HttpGet]
    public IActionResult GetStorageView()
    {   
        // TODO: do not use in production
        WSManModule.HyperVMetric.test(false);
        //
        var response = MetricsService.Instance.GetRawMetrics();
        return ProcessResponse<StorageQuickView>(response);
    }
