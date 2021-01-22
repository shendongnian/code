    static public string DoubleToSortableString(double dbl)
    {
        Int64 interpretAsLong =
            BitConverter.ToInt64(BitConverter.GetBytes(dbl), 0);
        return LongToSortableString(interpretAsLong);
    }
    static public double DoubleFromSortableString(string str)
    {
        Int64 interpretAsLong =
            LongFromSortableString(str);
        return BitConverter.ToDouble(BitConverter.GetBytes(interpretAsLong), 0);
    }
    static public string LongToSortableString(long lng)
    {
        if (lng < 0)
            return "-" + (lng - long.MinValue).ToString("X16");
        else
            return "0" + lng.ToString("X16");
    }
    static public long LongFromSortableString(string str)
    {
        if (str.StartsWith("-"))
            return long.Parse(str.Substring(1, 16), NumberStyles.HexNumber) 
                   + long.MinValue;
        else
            return long.Parse(str.Substring(1, 16), NumberStyles.HexNumber);
    }
