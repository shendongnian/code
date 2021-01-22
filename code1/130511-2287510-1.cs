    private static string ToDelimitedString(string input, int position, string delimiter)
    {
      StringBuilder sb = new StringBuilder(input);
      int x = input.Length / position;
      while (--x > 0)
      {
        sb = sb.Insert(x * position, delimiter);
      }
      return sb.ToString();
    }
