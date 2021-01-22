    public class ConfigurationSettings:BaseConfiguration
    {
        #region App setting
        public static string ApplicationName
        {
            get { return (string)GetAppSetting(typeof(string), "ApplicationName"); }
        }
        public static string MailBccAddress
        {
            get { return (string)GetAppSetting(typeof(string), "MailBccAddress"); }
        }
        public static string DefaultConnection
        {
            get { return (string)GetAppSetting(typeof(string), "DefaultConnection"); }
        }
        #endregion App setting
        #region global setting
        #endregion global setting
    }
