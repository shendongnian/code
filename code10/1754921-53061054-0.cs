    public class AppSettingsWrapper
    {
        private AppSettings _settings;
        public AppSettingsWrapper(IOptionsMonitor<AppSettings> settings)
        {
            _settings = settings.CurrentValue;
            
            // Hook in on the OnChange event of the monitor
            settings.OnChange(Listener);
        }
        private void Listener(AppSettings settings)
        {
            _settings = settings;
        }
        // Example getter
        public string ExampleOtherApiUrl => _settings.ExampleOtherApiUrl;
    }
