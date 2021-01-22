    public sealed class CarConfigurationSettings
    {
        public string Make{get; set; }
        static readonly CarConfigurationSettings instance=
                                        new CarConfigurationSettings();
    
        static CarConfigurationSettings()
        {
        }
    
        CarConfigurationSettings()
        {
        }
    
        public static CarConfigurationSettings Instance
        {
            get
            {
                return instance;
            }
        }
    }
