    using System;
    using System.Linq;
    using System.Globalization;
    // ...
      // Sample input char.
      char c = (char)0x20; // space
      // The set of Unicode character categories containing non-rendering,
      // unknown, or incomplete characters.
      // !! Unicode.Format and Unicode.PrivateUse can NOT be included in
      // !! this set, because they may (private-use) or do (format)
      // !! contain at least *some* rendering characters.
      var nonRenderingCategories = new UnicodeCategory[] {
        UnicodeCategory.Control,
        UnicodeCategory.OtherNotAssigned,
        UnicodeCategory.Surrogate };
      // Char.IsWhiteSpace() includes the ASCII whitespace characters that
      // are categorized as control characters. Any other character is
      // printable, unless it falls into the non-rendering categories.
      var isPrintable = Char.IsWhiteSpace(c) ||
        ! nonRenderingCategories.Contains(Char.GetUnicodeCategory(c));
