    public interface ICheckPeriod
    {
        int Max { get; set; }
        int Seed { get; set; }
    }
    public class CheckPeriod : ICheckPeriod
    {
        public int Max { get; set; } = 2;
        public int Seed { get; set; } = 7;
    }
    services.AddTransient<ICheckPeriod, CheckPeriod>();
