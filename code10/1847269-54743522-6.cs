             static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings["FolderPath"] == null)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form2());
            }
         }
