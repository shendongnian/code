    public void RemoveLogs(DateTime cutOff)
    {
        foreach (string s in Directory.EnumerateFiles(@"e:\temp"))
        {
            int pos = s.LastIndexOf("-");
            if (pos != -1)
            {
                if (pos + 9 < s.Length)
                {
                    string date = s.Substring(pos + 1, 8);
                    if (DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateFile))
                    {
                        if(dateFile < cutOff)
                            File.Delete(s);
                    }
                }
            }
        }
    }
