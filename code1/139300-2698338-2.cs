      if (Properties.Settings.Default.UpgradeRequired)
      {
          Properties.Settings.Default.Upgrade();
          Properties.Settings.Default.UpgradeRequired = false;
          Properties.Settings.Default.Save();
      }
