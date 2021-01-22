    /// <summary>
    /// Split a string on each occurrence of a capital (assumed to be a word)
    /// e.g. MyBigToe returns "My Big Toe"
    /// </summary>
    public static string SplitCapitalizedWords(this string source)
    {
      if (String.IsNullOrEmpty(source)) return String.Empty;
      var newText = new StringBuilder(source.Length * 2);
      newText.Append(source[0]);
      for (int i = 1; i < source.Length; i++)
      {
        if (char.IsUpper(source[i]))
          newText.Append(' ');
        newText.Append(source[i]);
      }
      return newText.ToString();
    }
