    public static string ToTrimmedString(this decimal num)
    {
        string str = num.ToString();
        string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        if (str.Contains(decimalSeparator))
        {
            str = str.TrimEnd('0');
            if(str.EndsWith(decimalSeparator))
            {
                str = str.RemoveFromEnd(1);
            }
        }
        return str;
    }
    public static string RemoveFromEnd(this string str, int characterCount)
    {
        return str.Remove(str.Length - characterCount, characterCount);
    }
