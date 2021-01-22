    //  using System.Text.RegularExpressions;
    
    /// <summary>
    ///  Regular expression built for C# on: Thu, Mar 11, 2010, 04:37:21 PM
    ///  Using Expresso Version: 3.0.2766, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  <span.*?class="
    ///      <span
    ///      Any character, any number of repetitions, as few as possible
    ///      class="
    ///  [1]: A numbered capture group. [.*?]
    ///      Any character, any number of repetitions, as few as possible
    ///  ".*?lang="
    ///      "
    ///      Any character, any number of repetitions, as few as possible
    ///      lang="
    ///  [2]: A numbered capture group. [.*?]
    ///      Any character, any number of repetitions, as few as possible
    ///  ">
    ///      ">
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          "<span.*?class=\"(.*?)\".*?lang=\"(.*?)\">",
        RegexOptions.IgnoreCase
        | RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
    
    
    // This is the replacement string
    public static string regexReplace = 
          "<span class=\"$1\" lang=\"$2\" onDblClick=\"window.external."+
          "MyFunction(ThisLanguage)\">\r\n";
    
    
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
