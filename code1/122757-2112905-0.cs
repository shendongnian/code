public Regex MyRegex = new Regex(
      "(.+\\|)(.+)\\|(\\d{1,})\\|(.+)",
    RegexOptions.IgnoreCase
    | RegexOptions.CultureInvariant
    | RegexOptions.IgnorePatternWhitespace
    | RegexOptions.Compiled
    );
// This is the replacement string
public string MyRegexReplace = 
      "$1$2\\$3\\$4";
//// Replace the matched text in the InputText using the replacement pattern
string result = MyRegex.Replace(InputText,MyRegexReplace);
