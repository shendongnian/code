    public static int WordCount(this string s)
    {
      return str.Split(new char[] { ' ', '.', '?' },
        StringSplitOptions.RemoveEmptyEntries).Length;
    }
