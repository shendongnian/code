    protected static int FindNDigit(decimal value, int position)
    {
        var index = value.ToString().IndexOf(".");
        position = position + index;
        return (int)Char.GetNumericValue(value.ToString(), position);
    }
