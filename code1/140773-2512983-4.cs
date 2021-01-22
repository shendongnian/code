    class MyClass : IComposite
    {
        DateTime IGetAlarms.LastRuntime { get; set; }
        DateTime IGetDiagnostics.LastRuntime { get; set; }
        ...
    }
