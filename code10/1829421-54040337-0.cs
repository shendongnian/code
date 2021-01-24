    public static bool TryParse(this string input, out int? output)
    {
        var IsNumber = int.TryParse(input, out int result);
        if (!IsNumber)
            output = null;
        else
            output = result;
        return IsNumber; 
    }
