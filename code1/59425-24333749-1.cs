    using System.Configuration;
    
     private void button1_Click(object sender, EventArgs e)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        config.AppSettings.Settings.Remove("DBServerName");
        config.AppSettings.Settings.Add("DBServerName", "FirstAddedValue1");
        config.Save(ConfigurationSaveMode.Modified);
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        config.AppSettings.Settings.Remove("DBServerName");
        config.AppSettings.Settings.Add("DBServerName", "SecondAddedValue1");
        config.Save(ConfigurationSaveMode.Modified);
    }
    
    private void button3_Click(object sender, EventArgs e)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
              MessageBox.Show(config.AppSettings.Settings["DBServerName"].Value);
    }
