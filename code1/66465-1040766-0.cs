    public static int GetDecimalAsInt(this float num)
    {
        string s = n.ToString();
        int separator = s.IndexOf(System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
        return int.Parse(s.Substring(separator + 1));
    }
    // Usage:
    float pi = 3.14;
    int digits = pi.GetDecimalAsInt();
