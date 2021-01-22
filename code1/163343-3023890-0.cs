    // Get the entire dataset from the database using the SettingsSelAll command.
    private DataTable GetVersionData() {...}
    // Parse a version from the dataset.
    private Version GetVersion(string versionName, DataTable dataSet) { ... }
    public Version GetVersion(string versionName)
    {
        DataTable table = GetVersionData();
        return GetVersion(versionName, table);
    }
