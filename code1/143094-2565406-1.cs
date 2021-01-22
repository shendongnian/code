        public class UserSettings : ApplicationSettingsBase
            {
                private static UserSettings defaultInstance = ((UserSettings)(ApplicationSettingsBase.Synchronized(new UserSettings())));
        
                public static UserSettings Default
                {
                    get
                    {
                        return defaultInstance;
                    }
                }
    
                [UserScopedSetting()]
                public string MyProperty
                {
                    get { return (string)this["MyProperty"]; }
                    set { this["MyProperty"] = (string)value; }
                }
                //add more properties
    }
