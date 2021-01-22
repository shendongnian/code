    public static int GetInteger(this string value)
    {
        return new string(str.ToCharArray().TakeWhile(
            c => char.IsNumber(c)).ToArray());
    }
