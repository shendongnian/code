    public IEnumerable<string> SplitAndKeepPrefix(this string source, string delimeter) {
      return SplitAndKeepPrefix(source, delimeter, StringSplitOptions.None);
    }
    
    public IEnumerable<string> SplitAndKeepPrefix(this string source, string delimeter, StringSplitOptions options ) {
      var split = source.Split(delimeter, options);
      return split.Take(1).Concat(split.Skip(1).Select(x => delimeter + x));
    }
    
    string result = htmlStr.SplitAndKeepPrefix("<a");
