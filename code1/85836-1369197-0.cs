    public static bool IsInt(this string str)
    {
        int i;
        return int.TryParse(str, out i);
    }
