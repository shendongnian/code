    public override string ToString()
    {
        return ToString("g", null); // Always support "g" as default format.
    }
     
    public string ToString(string format)
    {
      return ToString(format, null);
    }
    
    public string ToString(IFormatProvider formatProvider)
    {
      return ToString(null, formatProvider);
    }
 
    public string ToString(string format, IFormatProvider formatProvider)
    {
      if (format == null) format = "g"; // Set default format, which is always "g".
      // Continue formatting by checking format specifiers and options.
    }
