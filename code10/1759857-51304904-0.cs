    foreach (string s in Registry.CurrentUser.OpenSubKey("Software\\Microsoft").GetSubKeyNames())
    {
        if (s.All(Char.IsDigit))
        {
            Registry.CurrentUser.DeleteSubKey($"Software\\Microsoft\\{s}");
        }
    }
