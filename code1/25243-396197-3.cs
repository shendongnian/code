    public static class mySettings
    {
        public enum SettingsType
        { UserPermitions, WebService, Alerts }
        public enum SectionType
        { AllowChangeLayout, AllowUserDelete, MaximumReturnsFromSearch, MaximumOnBatch, SendTo }
    
        public static String GetSettings(SettingsType type, SectionType section)
        {
            return
                ConfigurationManager.AppSettings[
                    String.Format("{0}_{1}",
                        Enum.Parse(typeof(SettingsType), type.ToString()).ToString(),
                        Enum.Parse(typeof(SectionType), section.ToString()).ToString())
                ];
        }
    }
