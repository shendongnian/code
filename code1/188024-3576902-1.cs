    public class UsageExample
    {
        void Usage()
        {
            string mySetting = Settings.GetAppSettingValue("MySetting");
            var section = Settings.Configuration.GetSection("MySection");
        }
    }
