    public class MyUserSettings : ApplicationSettingsBase
    {
        public MyUserSettings()
            : base()
        {
            Providers.Clear();
            Providers.Add(new CustomProvider());
        }
        ...
    }
