    public class BusinessLogic
    {
         private IOptionsSnapshot<LibrarySettings> _settings;
         public BusinessLogic(IOptionsSnapshot<LibrarySettings> settings)
         {
             _settings = settings;
         }
         public string GetValueA => _settings.Value.SettingA;
         public string GetValueB => _settings.Value.SettingB;
     }
