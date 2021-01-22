    public static string Shorten(this string str, int toLength, string cutOffReplacement = " ...")
    {
        if (string.IsNullOrEmpty(str) || str.Length <= toLength)
            return str;
        else
            return str.Remove(toLength) + cutOffReplacement;
    }
   
