    [EnvironmentSpecific("QA")]
    [Export(typeof(ISchedulerProvider))]
    public class TestProvider : ISchedulerProvider
    {
        public string Foo { get; } = "TestBar";
    }
    [EnvironmentSpecific("Prod")]
    [Export(typeof(ISchedulerProvider))]
    public class RealProvider : ISchedulerProvider
    {
        public string Foo { get; } = "RealBar";
    }
