    private void SpoofAppConfig(string connectionStringName, string connectionString)
        {
            var settings = ConfigurationManager.ConnectionStrings[connectionStringName];
            var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(settings, false);
            settings.ConnectionString = connectionString;
        }
