    //  using System.Text.RegularExpressions;
    /// <summary>
    ///  Regular expression built for C# on: Sun, Dec 27, 2009, 03:05:24 PM
    ///  Using Expresso Version: 3.0.3276, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  [Sentence]: A named capture group. [\S.+?(?<Terminator>[.!?]|\Z)]
    ///      \S.+?(?<Terminator>[.!?]|\Z)
    ///          Anything other than whitespace
    ///          Any character, one or more repetitions, as few as possible
    ///          [Terminator]: A named capture group. [[.!?]|\Z]
    ///              Select from 2 alternatives
    ///                  Any character in this class: [.!?]
    ///                  End of string or before new line at end of string
    ///  Match a suffix but exclude it from the capture. [\s+|\Z]
    ///      Select from 2 alternatives
    ///          Whitespace, one or more repetitions
    ///          End of string or before new line at end of string
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          "(?<Sentence>\\S.+?(?<Terminator>[.!?]|\\Z))(?=\\s+|\\Z)",
        RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
    
    
    // This is the replacement string
    public static string regexReplace = 
          "$& [${Day}-${Month}-${Year}]";
    
    
    //// Replace the matched text in the InputText using the replacement pattern
    // string result = regex.Replace(InputText,regexReplace);
    
    //// Split the InputText wherever the regex matches
    // string[] results = regex.Split(InputText);
    
    //// Capture the first Match, if any, in the InputText
    // Match m = regex.Match(InputText);
    
    //// Capture all Matches in the InputText
    // MatchCollection ms = regex.Matches(InputText);
    
    //// Test to see if there is a match in the InputText
    // bool IsMatch = regex.IsMatch(InputText);
    
    //// Get the names of all the named and numbered capture groups
    // string[] GroupNames = regex.GetGroupNames();
    
    //// Get the numbers of all the named and numbered capture groups
    // int[] GroupNumbers = regex.GetGroupNumbers();
