    public static string SelectedLanguage
    {
        get { return Settings.AppSettings.GetValueOrDefault(StringConstants.SelectedLanguage, SelectedLanguageDefault); }
        set { Settings.AppSettings.AddOrUpdateValue(StringConstants.SelectedLanguage, value); }
    }
