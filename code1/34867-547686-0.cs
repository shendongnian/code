    public static string MyHtmlEncode(string value)
    {
       // call the normal HtmlEncode first
       char[] chars = HttpUtility.HtmlEncode(value).ToCharArray();
       StringBuilder encodedValue = new StringBuilder();
       foreach(char c in chars)
       {
          if ((int)c > 127) // above normal ASCII
             encodedValue.Append("&#" + (int)c + ";");
          else
             encodedValue.Append(c);
       }
       return encodedValue.ToString();
    }
