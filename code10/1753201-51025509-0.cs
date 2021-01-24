    private static double Truncate(double d, int decimals)
    {
        string s = d.ToString(System.Globalization.CultureInfo.InvariantCulture);
        int index = s.IndexOf(System.Globalization.CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
        if (index > -1)
            return Convert.ToDouble($"{s.Substring(0, index + 1)}{s.Substring(index + 1, decimals)}", System.Globalization.CultureInfo.InvariantCulture);
        return d;
    }
