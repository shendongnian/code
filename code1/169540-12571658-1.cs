    public static bool In(this string str, string CommaDelimintedStringSet)
    {
        string[] Values = CommaDelimintedStringSet.Split(new char[] { ',' });
        foreach (string V in Values)
        {
           if (str == V)
             return true;
        }
        return false;
    }
