    void Main() {
        string text = "\"one\" *two** and a bit \"three *** four\"";
        string finderRegex = @"
            (""[^""]*"")           # quoted
          | ([^\s""*]*\*[^\s""]*)  # with asteriks
          | ([^\s""]+)             # without asteriks
        ";
        return Regex.Replace(text, finderRegex, ArgumentReplacer,
                RegexOptions.IgnorePatternWhitespace);
    }
    public static String ArgumentReplacer(Match theMatch) {
        // Don't touch quoted arguments, and arguments with no asteriks
        if (theMatch.Groups[2].Value.Length == 0)
            return theMatch.Value;
        // Quote arguments with asteriks, and replace sequences of such
        // by a single one.
        return String.Format("\"%s\"",
              Regex.Replace(theMatch.Value, @"\*\*+", "*"));
    }
