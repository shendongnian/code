[System.ArgumentException: parsing "\p{Han}+" - Unknown property 'Han'.]
   at System.Text.RegularExpressions.RegexCharClass.SetFromProperty(String capname, Boolean invert, String pattern)
   at System.Text.RegularExpressions.RegexCharClass.AddCategoryFromName(String categoryName, Boolean invert, Boolean caseInsensitive, String pattern)
   at System.Text.RegularExpressions.RegexParser.ScanBackslash()
   at System.Text.RegularExpressions.RegexParser.ScanRegex()
   at System.Text.RegularExpressions.RegexParser.Parse(String re, RegexOptions op)
   at System.Text.RegularExpressions.Regex..ctor(String pattern, RegexOptions options, TimeSpan matchTimeout, Boolean useCache)
   at System.Text.RegularExpressions.Regex..ctor(String pattern)
Detailed infos are [referenced here][1].
  [1]: https://www.regular-expressions.info/unicode.html
