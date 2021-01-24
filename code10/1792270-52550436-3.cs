    public static string ApplyPattern(string value, string mask) {
      if (null == value)
        throw new ArgumentNullException("value");
      else if (null == mask)
        throw new ArgumentNullException("mask");
      else if (mask.Count(c => c == 'X') != value.Length)
        throw new ArgumentException("Inconsistent mask", "mask"); 
      int index = 0;
      // index++ - side effect - which is, however, safe in the context
      return string.Concat(mask
        .Select(c => c == 'X' ? value[index++] : c));
    }
