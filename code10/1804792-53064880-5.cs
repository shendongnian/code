    class Program
        {
    
            static void Main(string[] args)
            {
                var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true);
    
                var configuration = builder.Build();
    
                var settings = new LibrarySettings();
    
                configuration.GetSection("LibrarySettings").Bind(settings);
    
                var x = settings.SettingA;
            }
    
        }
    
        public class BusinessLogic
        {
            private LibrarySettings _settings;
    
            public BusinessLogic(IOptionsSnapshot<LibrarySettings> settings)
            {
                _settings = settings.Value;
            }
    
            public string GetValueA => _settings.SettingA;
    
            public string GetValueB => _settings.SettingB;
        }
        public class LibrarySettings
        {
            public string SettingA { get; set; }
            public string SettingB { get; set; }
            public LibrarySettings() { }
        }
