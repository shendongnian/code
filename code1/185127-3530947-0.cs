    public class ConfigurationBase
    {
        public static string Something
        {
            get { return ConfigurationManager.AppSettings["Something"]; }
        }
        // ....
    }
