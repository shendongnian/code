    //Datetime compare.
    private int CompareTime(string t1, string t2)
    {
        TimeSpan s1 = TimeSpan.Parse(t1);
        TimeSpan s2 = TimeSpan.Parse(t2);
        return s2.CompareTo(s1);
    }
