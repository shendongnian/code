    if(string.IsnullOrEmpty(Settings.Default.FileDirectory))
    {
    Settings.Default.FileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    Settings.Default.Save();
    }
    
