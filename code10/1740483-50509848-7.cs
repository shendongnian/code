    public class SettingsConverter
    {
        public Settings Convert(IDictionary<string, string> data)
        {
            return new Settings
            {
                Enabled = data["ENABLED"].Equals("Y", StringComparison.Ordinal),
                ...
            };
        }
    }
