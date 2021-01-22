    public static TimeSpan ToTimeSpan(this string s)
    {
      TimeSpan t = TimeSpan.Parse(s.Remove(2, 1).Remove(5, 1));
      return t;
    }
