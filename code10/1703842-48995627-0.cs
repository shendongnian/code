    public static string GetBinaryString(this byte input)
    {
        return Convert.ToString(input, 2).PadLeft(8, '0');
    }
   
