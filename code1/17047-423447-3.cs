    // Calls the underlying int.TryParse method to convert a string
    // representation of a number to its 32-bit signed integer equivalent.
    // Returns Zero if conversion fails. 
    public static int ToInt32(this string s)
    {
        int retInt;
        int.TryParse(s, out retInt);
        return retInt;
    }
