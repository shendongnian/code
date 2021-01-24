    private void ApplicationUpdate()
        {
            string FullfilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            string VersionDirectoryfilePath = Path.GetFullPath(Path.Combine(FullfilePath, @"..\..\" + DeleteThisVersionDirectory));
            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
                Directory.Delete(VersionDirectoryfilePath, true);
            }
        }
