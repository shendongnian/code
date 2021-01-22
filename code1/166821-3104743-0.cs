    public static string TrimDecimal(decimal value)
    {
        string result = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        if (result.IndexOf('.') == -1)
            return result;
        return result.TrimEnd('0', '.');
    }
