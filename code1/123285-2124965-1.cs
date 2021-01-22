    static void Main()
       {
       // if user setting program version user setting is less than
       MyProject.Properties.Settings config = new MyProject.Properties.Settings();
       string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
       if (config.Version != version)
       {
          // migrate from version 1.0.2 to future versions here...
          if (config.Version == null)
          {
          }
          config.Upgrade();
          config.Reload();
          config.Version = version;
          config.Save();
       }
