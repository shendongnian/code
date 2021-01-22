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
        return BitConverter.ToDouble(BitConverter.GetBytes(interpretAsLong, 0));
    }
