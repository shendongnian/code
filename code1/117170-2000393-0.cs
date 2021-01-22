    String s = "2009-12-28T24:11:48Z";
    DateTime dt;
    if (s.Contains("T24:")
    {
        s = s.Replace("T24:", "T00:");
        
        if (DateTime.TryParse(s, out dt))
            dt.AddDays(1);
    }
    else
    {
        DateTime.TryParse(s, out dt);
    }
