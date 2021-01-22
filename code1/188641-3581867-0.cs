    internal partial class Settings {
      private static Settings _debugInstance = ApplicationSettingsBase.Synchronized(new Settings());
      internal static Settings Debug { 
        get { return _debugInstance; }
      }
    }
        
