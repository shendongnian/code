    public static Dictionary<string, string> ParseIniDataWithSections(string[] iniData)
    {
        var dict = new Dictionary<string, string>();
        var rows = iniData.Where(t => 
            !String.IsNullOrEmpty(t.Trim()) && !t.StartsWith(";") && (t.Contains('[') || t.Contains('=')));
        if (rows == null || rows.Count() == 0) return dict;
        string section = "";
        foreach (string row in rows)
        {
            string rw = row.TrimStart();
            if (rw.StartsWith("["))
                section = rw.TrimStart('[').TrimEnd(']');
            else
            {
                int index = rw.IndexOf('=');
                dict[section + "-" + rw.Substring(0, index).Trim()] = rw.Substring(index+1).Trim().Trim('"');
            }
        }
        return dict;
    }
