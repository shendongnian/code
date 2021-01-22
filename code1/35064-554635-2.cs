    int pathLenght = executablePath.Length + 1;
    foreach (string s in directories)
    {
        try
        {
            cmbLanguage.Items.Add(CultureInfo.GetCultureInfo(s.Remove(0, pathLenght)));
        }
        catch (Exception)
        {
    
        }
    }
