    public static string SmartTrim(this string s, int length)
    {
        if(s == null || length < 0 || s.Length <= length)
            return s;
        
        string temp = s.Length > length + 1 ? s.Remove(length+1) : s;
        int lastSpace = temp.LastIndexOf(' ');
        return lastSpace < 0 ? string.Empty : temp.Remove(lastSpace);
    }
