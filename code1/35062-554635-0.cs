    string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
    string[] directories = Directory.GetDirectories(executablePath);
    foreach (string s in directories)
    {
        try
        {
            DirectoryInfo langDirectory = new DirectoryInfo(s);
            cmbLanguage.Items.Add(CultureInfo.GetCultureInfo(langDirectory.Name));
        }
        catch (Exception)
        {
    
        }
    }
