    public static string SelectedLanguage
    {
        get { return Settings.AppSettings.GetValueOrDefault(StringConstants.SelectedLanguage, SelectedLanguageDefault); }
        set { Settings.AppSettings.AddOrUpdateValue(StringConstants.SelectedLanguage, value); }
    }
    public static bool FirstRun
        {
            get { return Settings.AppSettings.GetValueOrDefault(StringConstants.FirstRun, FirstRunDefault); }
            set { Settings.AppSettings.AddOrUpdateValue(StringConstants.FirstRun, value); }
        }
        public static int LatestUpdateVersion
        {
            get { return Settings.AppSettings.GetValueOrDefault(StringConstants.LatestUpdateVersion, LatestUpdateVersionDefault); }
            set { Settings.AppSettings.AddOrUpdateValue(StringConstants.LatestUpdateVersion, value); }
        }
        public static string LatestUpdateVersionDate
        {
            get { return Settings.AppSettings.GetValueOrDefault(StringConstants.LatestUpdateVersionDate, LatestUpdateVersionDateDefault); }
            set { Settings.AppSettings.AddOrUpdateValue(StringConstants.LatestUpdateVersionDate, value); }
        }
