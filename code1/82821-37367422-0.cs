    [Serializable]
    public class ReportType
    {
        public string DisplayName { get; set; }
        public string ReportName { get; set; }
        public ReportType() { }
        public ReportType(string displayName, string reportName)
        {
            DisplayName = displayName;
            ReportName = reportName;
        }
    }
    
    // the class responsible for reading and writing the settings
    public sealed class ReportTypeSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        [DefaultSettingValue("")]
        public ReportType ReportType
        {
            get { return (ReportType)this[nameof(ReportType)]; }
            set { this[nameof(ReportType)] = value; }
        }
    }
