    public class TestVm
    {
        public ReportConfigurationType ConfigType { get; set; }   
        public string Name { get; set; }
    }
    public class ConfigurationViewModel
    {
        public List<TestVm> ReportConfigurations { get; set; }
    }
