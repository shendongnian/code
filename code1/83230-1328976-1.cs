    public static string trimIt(string s)
    {
       if(s == null)
           return string.Empty;
       int count = Math.Min(s.Length, 250);
       return s.Substring(0, count);
    }
