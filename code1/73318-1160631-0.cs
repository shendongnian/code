    public static bool IsNumeric(this string value)
    {
        double temp;
        return double.TryParse(value.ToString(), out temp);
    }
