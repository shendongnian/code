    public static class MyStringExtensions{  
    public static string RemoveCharactersFromEnd(this string s, int n)  
    {  
        string result = string.Empty;  
        if (string.IsNullOrEmpty(s) == false
            && n > 0)
        {
            result = s.Remove(s.Length - n, n);
        }
        return result;
    }}  
