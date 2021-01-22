    string MagicFunction(string InputText) {
        public static Regex regex = new Regex(
              "(^|\\r\\n)",
            RegexOptions.IgnoreCase
            | RegexOptions.CultureInvariant
            | RegexOptions.IgnorePatternWhitespace
            | RegexOptions.Compiled
            );
        
        // This is the replacement string
        public static string regexReplace = 
              "$1-- ";
        
        // Replace the matched text in the InputText using the replacement pattern
        string result = regex.Replace(InputText,regexReplace);
    
        return result;
    }
