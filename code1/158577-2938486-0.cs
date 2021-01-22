    public static string MakeEmailsClickable( string input ){
      if (string.IsNullOrEmpty(input) ) return input;
      Regex emailFinder = new Regex(@"[^\s]+@[^\s\.]+.[^\s]+", RegexOptions.IgnoreCase);
      return emailFinder.Replace(input, "<a href=\"mailto:$&\">$&</a>" );
    }
