    public static class SettingClass
    {
        const string userNameKey = "UserName";
        const string userNameDefault = "";
        public static DataService DataServiceObj = new DataService();
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }
       
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(userNameKey, userNameDefault);
            set => AppSettings.AddOrUpdateValue(userNameKey, value);
        }
    }
