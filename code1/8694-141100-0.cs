    public static class StringExt
    {
        public static string ReplaceFirstOccurrence(this string s, string oldValue, string newValue)
        {
             int i = s.IndexOf(oldValue);
             return s.Remove(i, oldValue.Length).Insert(i, newValue);    
        } 
    }
