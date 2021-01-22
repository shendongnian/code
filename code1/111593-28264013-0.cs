    public static void SaveFormLocationAndSize(object sender, FormClosingEventArgs e)
    {
        Form xForm = sender as Form;
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        if (ConfigurationManager.AppSettings.AllKeys.Contains(xForm.Name))
            config.AppSettings.Settings[xForm.Name].Value = String.Format("{0};{1};{2};{3}", xForm.Location.X, xForm.Location.Y, xForm.Size.Width, xForm.Size.Height);
        else
            config.AppSettings.Settings.Add(xForm.Name, String.Format("{0};{1};{2};{3}", xForm.Location.X, xForm.Location.Y, xForm.Size.Width, xForm.Size.Height));
        config.Save(ConfigurationSaveMode.Full);
    }
