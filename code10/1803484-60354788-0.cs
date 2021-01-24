    public static bool IsVC2015x86Installed()
    {
        string dependenciesPath = @"SOFTWARE\Classes\Installer\Dependencies";
        using (RegistryKey dependencies = Registry.LocalMachine.OpenSubKey(dependenciesPath))
        {
            if (dependencies == null) return false;
            foreach (string subKeyName in dependencies.GetSubKeyNames().Where(n => !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft")))
            {
                using (RegistryKey subDir = Registry.LocalMachine.OpenSubKey(dependenciesPath + "\\" + subKeyName))
                {
                    var value = subDir.GetValue("DisplayName")?.ToString() ?? null;
                    if (string.IsNullOrEmpty(value)) continue;
                    if (Regex.IsMatch(value, @"C\+\+ 2015.*\(x86\)")) //here u can specify your version.
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
