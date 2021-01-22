    // Login sucessfully...
    Utility.UserPreferences pref = new Utility.UserPreferences(CurrentUser.ID);
    // to retrieve a preference
    string language = Utility.UserPreferences.GetPreferences(
                            Utility.UserPreferences.PreferencesType.Language,
                            CurrentUser.ID);
