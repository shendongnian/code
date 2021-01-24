    public static string ToStringN(this ValueType value)
    {
        return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
    }
    // usage:
    int a = 10;
    a.toStringN();
