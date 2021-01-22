    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Web.Configuration;
    
    namespace System
    {
        /// <summary>
        /// Extension methods for the string data type
        /// </summary>
        public static class ConventionBasedFormattingExtensions
        {
            /// <summary>
            /// Turn CamelCaseText into Camel Case Text.
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            /// <remarks>Use AppSettings["SplitCamelCase_AllCapsWords"] to specify a comma-delimited list of words that should be ALL CAPS after split</remarks>
            /// <example>
            /// wordWordIDWord1WordWORDWord32Word2
            /// Word Word ID Word 1 Word WORD Word 32 Word 2
            /// 
            /// wordWordIDWord1WordWORDWord32WordID2ID
            /// Word Word ID Word 1 Word WORD Word 32 Word ID 2 ID
            /// 
            /// WordWordIDWord1WordWORDWord32Word2Aa
            /// Word Word ID Word 1 Word WORD Word 32 Word 2 Aa
            /// 
            /// wordWordIDWord1WordWORDWord32Word2A
            /// Word Word ID Word 1 Word WORD Word 32 Word 2 A
            /// </example>
            public static string SplitCamelCase(this string input)
            {
                if (input == null) return null;
                if (string.IsNullOrWhiteSpace(input)) return "";
    
                var separated = input;
    
                separated = SplitCamelCaseRegex.Replace(separated, @" $1").Trim();
    
                //Set ALL CAPS words
                if (_SplitCamelCase_AllCapsWords.Any())
                    foreach (var word in _SplitCamelCase_AllCapsWords)
                        separated = SplitCamelCase_AllCapsWords_Regexes[word].Replace(separated, word.ToUpper());
    
                //Capitalize first letter
                var firstChar = separated.First(); //NullOrWhiteSpace handled earlier
                if (char.IsLower(firstChar))
                    separated = char.ToUpper(firstChar) + separated.Substring(1);
    
                return separated;
            }
    
            private static readonly Regex SplitCamelCaseRegex = new Regex(@"
                (
                    (?<=[a-z])[A-Z0-9] (?# lower-to-other boundaries )
                    |
                    (?<=[0-9])[a-zA-Z] (?# number-to-other boundaries )
                    |
                    (?<=[A-Z])[0-9] (?# cap-to-number boundaries; handles a specific issue with the next condition )
                    |
                    (?<=[A-Z])[A-Z](?=[a-z]) (?# handles longer strings of caps like ID or CMS by splitting off the last capital )
                )"
                , RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace
            );
    
            private static readonly string[] _SplitCamelCase_AllCapsWords =
                (WebConfigurationManager.AppSettings["SplitCamelCase_AllCapsWords"] ?? "")
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.ToLowerInvariant().Trim())
                    .ToArray()
                    ;
    
            private static Dictionary<string, Regex> _SplitCamelCase_AllCapsWords_Regexes;
            private static Dictionary<string, Regex> SplitCamelCase_AllCapsWords_Regexes
            {
                get
                {
                    if (_SplitCamelCase_AllCapsWords_Regexes == null)
                    {
                        _SplitCamelCase_AllCapsWords_Regexes = new Dictionary<string,Regex>();
                        foreach(var word in _SplitCamelCase_AllCapsWords)
                            _SplitCamelCase_AllCapsWords_Regexes.Add(word, new Regex(@"\b" + word + @"\b", RegexOptions.Compiled | RegexOptions.IgnoreCase));
                    }
    
                    return _SplitCamelCase_AllCapsWords_Regexes;
                }
            }
        }
    }
