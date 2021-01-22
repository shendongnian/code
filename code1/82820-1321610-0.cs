        public class ReportType : ApplicationSettingsBase
        {
            private string displayName;
            [UserScopedSetting()]
            [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
            public string DisplayName
            {
                get { return displayName; }
            }
