    public static Boolean IsValidInt32(String input)
    {
        Int32 number;
        return Int32.TryParse(input, out number);
    }
