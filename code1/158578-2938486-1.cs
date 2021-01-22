    public static string MakeUrlsClickable( string input ){
      if (string.IsNullOrEmpty(input) ) return input;
      Regex urlFinder = new Regex(@"(ftp|http(s)?)://[^\s]*", RegexOptions.IgnoreCase);
      return urlFinder.Replace(input, "<a href=\"$&\">$&</a>" );
    }
