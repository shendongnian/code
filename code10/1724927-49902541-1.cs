    public class MyLibraryClient
    {
        private readonly ISettingsProvider settingsProvider;
        public MyLibraryClient(ISettingsProvider settingsProvider)
        {
             this.settingsProvider = settingsProvider;
        }
    
        public void MyAwesomeMethod()
        {
            var settingA = settingsProvider.GetSettingA();
            // do more stuff with your settings
        }
    }
