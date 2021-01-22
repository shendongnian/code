    public DateTime GetDateTime(string value)
    {
      if (string.IsNullOrEmpty(value))
        return DateTime.MinValue;
        
      if ("{now}".Equals(value, StringComparison.InvariantCultureIgnoreCase))
        return DateTime.Now;
        
      return DateTime.Parse(value);
    }
