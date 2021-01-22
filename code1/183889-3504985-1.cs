    public static string SmartTrim(this string s, int length)
    {
        if(s == null || length < 0 || s.Length <= length)
            return s;
        
        // Edit a' la Jon Skeet. Removes unnecessary intermediate string. Thanks!
        // string temp = s.Length > length + 1 ? s.Remove(length+1) : s;
        int lastSpace = s.LastIndexOf(' ', length + 1);
        return lastSpace < 0 ? string.Empty : s.Remove(lastSpace);
    }
