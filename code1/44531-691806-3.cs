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
            return "-" + (~lng).ToString("X16");
        else
            return "0" + lng.ToString("X16");
    }
    static public long LongFromSortableString(string str)
    {
        if (str.StartsWith("-"))
            return ~long.Parse(str.Substring(1, 16), NumberStyles.HexNumber); 
        else
            return long.Parse(str.Substring(1, 16), NumberStyles.HexNumber);
    }
-0010000000000000 => -1.79769313486232E+308
-3F0795FFFFFFFFFF => -100000
-3F3C77FFFFFFFFFF => -10000
-3F70BFFFFFFFFFFF => -1000
-3FA6FFFFFFFFFFFF => -100
-3FDBFFFFFFFFFFFF => -10
-400FFFFFFFFFFFFF => -1
00000000000000000 => 0
03FF0000000000000 => 1
04024000000000000 => 10
04059000000000000 => 100
0408F400000000000 => 1000
040C3880000000000 => 10000
040F86A0000000000 => 100000
07FEFFFFFFFFFFFFF => 1.79769313486232E+308
