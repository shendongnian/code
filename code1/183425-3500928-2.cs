    namespace Example
    {
        public class SettingsRepository
        {
            public SettingsRepository()
            {
            }
        }
        public class SettingsForm
        {
            private SettingsRepository _settingsRepository;
            public SettingsForm( SettingsRepository settingsRepository )
            {
                _settingsRepository = settingsRepository;
            }
        }
        public class MainForm
        {
            private SettingsRepository _settingsRepository;
            private Func<SettingsForm> _createSettingsForm;
            public MainForm( Func<SettingsForm> createSettingsForm, SettingsRepository settingsRepository )
            {
                _createSettingsForm = createSettingsForm;
                _settingsRepository = settingsRepository;
            }
        }
    }
