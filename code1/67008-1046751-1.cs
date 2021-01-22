    public static bool IsAlphaNum(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;
    
        for (int i = 0; i < str.Length; i++)
        {
            if (!(char.IsLetter(str[i])) && (!(char.IsNumber(str[i]))))
                return false;
        }
    
        return true;
    }
