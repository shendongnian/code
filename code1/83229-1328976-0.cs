    public static string trimIt(string s)
    {
       int count = Math.Min(s.Length, 250);
       return s.Substring(0, count);
    }
