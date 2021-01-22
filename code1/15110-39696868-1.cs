    public static string Replace(string str, string oldValue, string newValue, StringComparison comparison)
    {
        if (oldValue == null)
            throw new ArgumentNullException("oldValue");
        if (oldValue.Length == 0)
            throw new ArgumentException("String cannot be of zero length.", "oldValue");
	
        StringBuilder sb = null;
        int startIndex = 0;
        int foundIndex = str.IndexOf(oldValue, comparison);
        while (foundIndex != -1)
        {
            if (sb == null)
                sb = new StringBuilder(str.Length + (newValue != null ? Math.Max(0, 5 * (newValue.Length - oldValue.Length)) : 0));
            sb.Append(str, startIndex, foundIndex - startIndex);
            sb.Append(newValue);
	
            startIndex = foundIndex + oldValue.Length;
            foundIndex = str.IndexOf(oldValue, startIndex, comparison);
        }
	
        if (startIndex == 0)
            return str;
        sb.Append(str, startIndex, str.Length - startIndex);
        return sb.ToString();
    }
