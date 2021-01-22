    public IEnumerable<string> SplitAndKeepPrefix(this string source, string delimeter) {
      return SplitAndKeepPrefix(source, delimeter, StringSplitOptions.None);
    }
    
    public IEnumerable<string> SplitAndKeepPrefix(this string source, string delimeter, StringSplitOptions options ) {
      return source.Split(delimeter, options).Select(x => delimeter + x);
    }
    
    string result = htmlStr.SplitAndKeepPrefix("<a");
