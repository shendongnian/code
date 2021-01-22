    public static string ToValidFileName(this string s, char replaceChar = '_', char[] includeChars = null)
    {
      var invalid = Path.GetInvalidFileNameChars();
      if (includeChars != null) invalid = invalid.Union(includeChars).ToArray();
      return string.Join(string.Empty, s.ToCharArray().Select(o => o.In(invalid) ? replaceChar : o));
    }
           
