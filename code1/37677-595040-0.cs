    public static Take(this string s, int i)
    {
        if(s.Length <= i)
            return s
        else
            return s.Substring(0, i) + "..."
    }
    
    public string ShortDescription
    {
        get { return this.Description.Take(25); }
    }
