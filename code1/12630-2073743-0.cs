    public interface ISettingsService
    {
        string ReadSetting(string name);
        void WriteSetting(string name, string value);
    }
    [Export]
    public class ObjectRequiringSettings
    {
        [Import]
        private ISettingsService SettingsService
        {
            get;
            set;
        }
        private void Foo()
        {
            if (SettingsService.ReadSetting("PerformFooAction") == bool.TrueString)
            {
                // whatever
            }
        }
    }
