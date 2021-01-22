    using System.Configuration;
    
    public class TryThis
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration("C:\PathTo\app.exe");
        
        public static void Main()
        {
            // Get something from the config to test.
            string test = config.AppSettings.Settings["TestSetting"].Value;
            
            // Set a value in the config file.
            config.AppSettings.Settings["TestSetting"].Value = test;
            
            // Save the changes to disk.
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
