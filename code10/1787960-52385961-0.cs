    private bool IsSchemeRegistered(string scheme)
    {
        using (var schemeKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(scheme))
        {
            if (schemeKey == null)
                return false;
            if (schemeKey.GetValue("") == null || !schemeKey.GetValue("").ToString().StartsWith("URL:"))
                return false;
            using (var shellKey = schemeKey.OpenSubKey("shell"))
            {
                if (shellKey == null)
                    return false;
                using (var openKey = shellKey.OpenSubKey("open"))
                {
                    if (openKey == null)
                        return false;
                    using (var commandKey = openKey.OpenSubKey("command"))
                    {
                        if (commandKey == null)
                            return false;
                        var command = commandKey.GetValue("") as string;
                        if (string.IsNullOrEmpty(command) || !File.Exists(command.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First()))
                            return false;
                    }
                }
            }
        }
        return true;
    }
