    static string CleanUpPeriods(string filename)
    {
        string extension = Path.GetExtension(filename);
        string name = Path.GetFileNameWithoutExtension(filename);
        Regex regex = new Regex(@"\.\.+");
        return regex.Replace(name, " ").Trim() + extension;
    }
