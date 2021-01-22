    static string CleanUpPeriods(string filename)
    {
        string extension = Path.GetExtension(filename);
        string name = Path.GetFileNameWithoutExtension(filename);
        Regex regex = new Regex(@"\.\.+");
        string s = regex.Replace(name, " ").Trim();
        if (s.EndsWith(".")) s = s.Substring(0, s.Length - 1);
        return s + extension;
    }
