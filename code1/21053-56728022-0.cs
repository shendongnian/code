        /// <summary>
        /// Add a space before any capitalized letter (but not for a run of capitals or numbers)
        /// </summary>
        internal static string FromCamelCaseToSentence(string input)
        {
            if (string.IsNullOrEmpty(input)) return String.Empty;
            var sb = new StringBuilder();
            bool upper = true;
            for (var i = 0; i < input.Length; i++)
            {
                bool isUpperOrDigit = char.IsUpper(input[i]) || char.IsDigit(input[i]);
                // any time we transition to upper or digits, it's a new word
                if (!upper && isUpperOrDigit)
                {
                    sb.Append(' ');
                }
                sb.Append(input[i]);
                upper = isUpperOrDigit;
            }
            return sb.ToString();
        }
