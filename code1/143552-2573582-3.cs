    public interface IMySettableSettingsControl
    {
        Dictionary<string, object> RetrieveSettings();
        void ApplySettings(Dictionary<string, object> settings);
    }
