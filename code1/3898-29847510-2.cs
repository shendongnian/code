       public Regex ConvertSqlLikeToDotNetRegex(string regex, char? likeEscape = null)
       {
            var pattern = string.Format(@"
                {0}[%_]|
                [%_]|
                \[[^]]*\]|
                [^%_[{0}]+
                ", likeEscape);
            var regexPattern = Regex.Replace(
                regex,
                pattern,
                ConvertWildcardsAndEscapedCharacters,
                RegexOptions.IgnorePatternWhitespace);
            regexPattern = "^" + regexPattern + "$";
            return new Regex(regexPattern,
                !m_CaseSensitive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }
        private string ConvertWildcardsAndEscapedCharacters(Match match)
        {
            // Wildcards
            switch (match.Value)
            {
                case "%":
                    return ".*";
                case "_":
                    return ".";
            }
            // Remove SQL defined escape characters from C# regex
            if (StartsWithEscapeCharacter(match.Value, likeEscape))
            {
                return match.Value.Remove(0, 1);
            }
            // Pass anything contained in []s straight through 
            // (These have the same behaviour in SQL LIKE Regex and C# Regex)
            if (StartsAndEndsWithSquareBrackets(match.Value))
            {
                return match.Value;
            }
            return Regex.Escape(match.Value);
        }
        private static bool StartsAndEndsWithSquareBrackets(string text)
        {
            return text.StartsWith("[", StringComparison.Ordinal) &&
                   text.EndsWith("]", StringComparison.Ordinal);
        }
        private bool StartsWithEscapeCharacter(string text, char? likeEscape)
        {
            return (likeEscape != null) &&
                   text.StartsWith(likeEscape.ToString(), StringComparison.Ordinal);
        }
