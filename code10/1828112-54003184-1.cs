    interface IMySettings
    {
        int LeftControl {get;}
        int RightControl {get;}
        ...
    }
    class ConfigurationSettings : IMySettings
    {
         // ConfigurationSettings reads settings from the configuration file
    }
    class MyClass
    {
        // default constructor use the configuration file via ConfigurationSettings:
        public MyClass() : this (new ConfigurationSettings())
        {
        }
        // extra constructor for those who don't want to use configuration file
        public MyClass(IMySettings settings)
        {
            this.Settings = settings;
        }
        protected readonly IMySettings settings;
        // MyClass uses settings:
        public int LeftControl => this.settings.LeftControl;
        public int RightControl => this.settings.RightControl;
    }
