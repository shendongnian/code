        /// <summary> Remove single or double quotes around an entry if any.  This also trims leading and trailing whitespace so
        ///           it's more like a positional parameter filter than pure unquoting. </summary>
        /// <param name="target"> Target string to unquote</param>
        /// <returns>             Trimmed and Unquoted string</returns>
        public static string UnQuote(this string target)
            => Regex.Replace(target, @"^\s*([\x22\x27])(.*)\1\s*$", "${2}");
