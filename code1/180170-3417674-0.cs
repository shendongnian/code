    [Flags]
    public enum RegexOptions
    {
      Compiled = 8,
      CultureInvariant = 0x200,
      ECMAScript = 0x100,
      ExplicitCapture = 4,
      IgnoreCase = 1,                 // i in Perl
      IgnorePatternWhitespace = 0x20, // x in Perl
      Multiline = 2,                  // m in Perl
      None = 0,
      RightToLeft = 0x40,
      Singleline = 0x10               // s in Perl
    }
