    [STAThread]
    static void Main()
    {
			// Ensures that the user setting's configuration system starts in an encrypted mode, otherwise an application restart is required to change modes.
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
			SectionInformation sectionInfo = config.SectionGroups["userSettings"].Sections["MyApp.Properties.Settings"].SectionInformation;
			if (!sectionInfo.IsProtected)
			{
				sectionInfo.ProtectSection(null);
				config.Save();
			}
			if (Settings.Default.UpgradePerformed == false)
				Settings.Default.Upgrade();
			Application.Run(new frmMain());
    }
