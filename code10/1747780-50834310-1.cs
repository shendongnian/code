    public static void German()
    {
        Log.Logger.Information("Language = German")
        ApplicationLanguages.PrimaryLanguageOverride = "de-DE";
        ApplicationData.Current.LocalSettings.Values["IsSwitchingLanguage"] = true;
        DataCollection.Current.LanguageChangedEvent.LanguageChanged();
    }
