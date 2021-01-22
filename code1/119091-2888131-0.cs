    /// <summary>
    /// Turn a string into something that's URL and Google friendly.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ForUrl(this string str) {
      return str.ForUrl(true);
    }
    public static string ForUrl(this string str, bool MakeLowerCase) {
      // Go to lowercase.
      if (MakeLowerCase) {
        str = str.ToLower();
      }
      // Replace accented characters for the closest ones:
      char[] from = "ÂÃÄÀÁÅÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝàáâãäåçèéêëìíîïðñòóôõöøùúûüýÿ".ToCharArray();
      char[] to = "AAAAAACEEEEIIIIDNOOOOOOUUUUYaaaaaaceeeeiiiidnoooooouuuuyy".ToCharArray();
      for (int i = 0; i < from.Length; i++) {
        str = str.Replace(from[i], to[i]);
      }
      // Thorn http://en.wikipedia.org/wiki/%C3%9E
      str = str.Replace("Þ", "TH");
      str = str.Replace("þ", "th");
      // Eszett http://en.wikipedia.org/wiki/%C3%9F
      str = str.Replace("ß", "ss");
      // AE http://en.wikipedia.org/wiki/%C3%86
      str = str.Replace("Æ", "AE");
      str = str.Replace("æ", "ae");
      // Esperanto http://en.wikipedia.org/wiki/Esperanto_orthography
      from = "ĈĜĤĴŜŬĉĝĥĵŝŭ".ToCharArray();
      to = "CXGXHXJXSXUXcxgxhxjxsxux".ToCharArray();
      for (int i = 0; i < from.Length; i++) {
        str = str.Replace(from[i].ToString(), "{0}{1}".Args(to[i*2], to[i*2+1]));
      }
      // Currencies.
      str = new Regex(@"([¢€£\$])([0-9\.,]+)").Replace(str, @"$2 $1");
      str = str.Replace("¢", "cents");
      str = str.Replace("€", "euros");
      str = str.Replace("£", "pounds");
      str = str.Replace("$", "dollars");
      // Ands
      str = str.Replace("&", " and ");
      // More aesthetically pleasing contractions
      str = str.Replace("'", "");
      str = str.Replace("’", "");
      // Except alphanumeric, everything else is a dash.
      str = new Regex(@"[^A-Za-z0-9-]").Replace(str, "-");
      // Remove dashes at the begining or end.
      str = str.Trim("-".ToCharArray());
      // Compact duplicated dashes.
      str = new Regex("-+").Replace(str, "-");
      // Let's url-encode just in case.
      return str.UrlEncode();
    }
