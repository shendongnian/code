    public abstract class BaseClass
    {
        protected virtual List<config> configs { get; set; } = new List<config>();
        public virtual void Start()
        {
            _timer.Start();
            foreach (var configuration in configs)
            {
                JsonSettings.CreateConfigFile(configuration);
            }
        }
    }
    public class DerivedClass1 : BaseClass
    {
        public DerivedClass1()
        {
            configs = JsonSettings.GetConfigurations(@"./Configurations/1.json");
        }
    }
    public class DerivedClass2 : BaseClass
    {
        public DerivedClass2()
        {
            configs = JsonSettings.GetConfigurations(@"./Configurations/2.json");
        }
    }
