    //  using System.Text.RegularExpressions;
    /// <summary>
    ///  Regular expression built for C# on: Tue, Oct 21, 2008, 02:34:30 PM
    ///  Using Expresso Version: 3.0.2766, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  Any character that is NOT in this class: [\\], any number of repetitions
    ///  End of line or string
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          @"[^\\]*$",
        RegexOptions.IgnoreCase
        | RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
