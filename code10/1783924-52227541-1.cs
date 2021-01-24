    public interface ICheckPeriod
    {
        int Max { get; set; }
        int Seed { get; set; }
    }
    
    public class CheckPeriod : ICheckPeriod
    {
        public int Max { get; set; }
        public int Seed { get; set; }
    }
     
    var checkPeriod = new CheckPeriod { Max = 2, Seed = 7 };
    services.AddSingleton<ICheckPeriod>(checkPeriod);
