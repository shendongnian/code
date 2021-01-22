    private static DateTime GetDate(string line)
    {
        int index = 0;
        DateTime theDate;
        string s = line;
        while(!DateTime.TryParse(s, out theDate))
        {
            index = line.IndexOf(" ", index);
            s = line.Substring(0, index);
        }
        return theDate;
    }
