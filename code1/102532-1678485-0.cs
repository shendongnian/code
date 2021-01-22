      if (!Properties.Settings.Default.Upgraded)
      {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.Upgraded = true;
        Properties.Settings.Default.Save();
        Trace.WriteLine("INFO: Settings upgraded from previous version");
      }
