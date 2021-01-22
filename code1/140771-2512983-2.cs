    interface IService
    {
        DateTime LastRuntime { get; set; }
    }
    
    interface IGetAlarms : IService
    {
        string GetAlarms();
    
    }
    
    interface IGetDiagnostics : IService
    {
        string GetDiagnostics();
    }
