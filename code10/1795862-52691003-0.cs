    public interface BaseClass
    {
        void Start();
    }
    public interface IBaseClassUtil
    {
        void Start();
        void setConfigs(List<config> configs);
    }
    public class BaseClassUtil : IBaseClassUtil
    {
        System.Timers.Timer _timer;
        public  List<config> _configs { get; set; } = new List<config>();
        public void Start()
        {
            _timer.Start();
            foreach (var configuration in _configs)
            {
                JsonSettings.CreateConfigFile(configuration);
            }
        }
        public void setConfigs(List<config> configs)
        {
            _configs = configs;
        }
    }
    public class DerivedClass1 : BaseClass
    {
        private IBaseClassUtil _baseUtility;
        public DerivedClass1(IBaseClassUtil baseUtility)
        {
            _baseUtility = baseUtility;
            _baseUtility.setConfigs( JsonSettings.GetConfigurations(@"./Configurations/1.json"));
        }
        public void Start()
        {
            _baseUtility.Start();
        }
    }
    public class DerivedClass2 : BaseClass
    {
        private IBaseClassUtil _baseUtility;
        public DerivedClass2(IBaseClassUtil baseUtility)
        {
            _baseUtility = baseUtility;
            _baseUtility.setConfigs(JsonSettings.GetConfigurations(@"./Configurations/2.json"));
        }
        public void Start()
        {
            _baseUtility.Start();
        }
    }
