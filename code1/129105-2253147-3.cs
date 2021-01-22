    static string BuildSeparatedString(string Element, string Sep, int count)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 1; i <= count; i++)
      {
        sb.Append(Element);
        if (i != count)
          sb.Append(Sep);
      }
      return sb.ToString();
    }
 
