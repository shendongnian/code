    static string BuildSeparatedString(string element, string sep, int count)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 1; i <= count; i++)
      {
        sb.Append(element);
        if (i != count)
          sb.Append(sep);
      }
      return sb.ToString();
    }
 
