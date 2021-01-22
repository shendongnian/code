    public static int GetInteger(this string value)
    {
        return Convert.ToInt32(str.Substring(0, str.ToCharArray().TakeWhile(
            c => char.IsNumber(c)).Count()));
    }
