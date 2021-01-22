        /// <summary>
        /// Quotes the provided string in a sql friendly way using the standard [ and ] characters 
        /// </summary>
        /// <param name="ObjectName">string to quote</param>
        /// <example>
        /// "mytable".QuoteSqlName() would return [mytable] 
        /// "my[complex]table".QuoteSqlName()  would return [my[[complex]]table]
        /// </example>
        /// <returns>quoted string wrapped by quoting characters</returns>
        /// <remarks>For dynamic sql this may need to be called multiple times, one for each level of encapsulation.</remarks>
        public static string QuoteSqlName(this string ObjectName)
        {
            return ObjectName.QuoteSqlName(']');
        }
        /// <summary>
        /// Quotes the provided string in a sql friendly way using the provided character
        /// </summary>
        /// <param name="ObjectName">string to quote</param>
        /// <param name="QuoteCharacter">Character to quote with, use [ or ] for standard sql quoting</param>
        /// <example>
        /// "mytable".QuoteSqlName() would return [mytable] 
        /// "my[complex]table".QuoteSqlName()  would return [my[[complex]]table]
        /// "justin's computer".QuoteSqlName('\'') would return 'justin''s computer'
        /// </example>
        /// <returns>quoted string wrapped by quoting characters</returns>
        public static string QuoteSqlName(this string ObjectName, char QuoteCharacter)
        {
            return ObjectName.QuoteSqlName(QuoteCharacter, false);
        }
        /// <summary>
        /// Quotes the provided string in a sql friendly way using the provided character
        /// </summary>
        /// <param name="ObjectName">string to quote</param>
        /// <param name="QuoteCharacter">Character to quote with, use [ or ] for standard sql quoting</param>
        /// <param name="IsNvarChar">if true and QuoteCharacter is ' will prefix the quote with N e.g. N'mytable' vs 'mytable'</param>
        /// <example>
        /// "mytable".QuoteSqlName() would return [mytable] 
        /// "my[complex]table".QuoteSqlName()  would return [my[[complex]]table]
        /// "justin's computer".QuoteSqlName('\'') would return 'justin''s computer'
        /// "mytable".QuoteSqlName('\'',false) would reutrn 'mytable'
        /// "mytable".QuoteSqlName('[',true) would return [mytable]
        /// "mytable".QuoteSqlName('\'',true) would reutrn N'mytable'
        /// </example>
        /// <returns>quoted string wrapped by quoting characters</returns>
        public static string QuoteSqlName(this string ObjectName, char QuoteCharacter, bool IsNvarChar)
        {
            if (string.IsNullOrEmpty(ObjectName))
                return ObjectName;
            char OtherQuoteCharacter = (char)0;
            bool UseOtherChar = false;
            if (QuoteCharacter == ']' || QuoteCharacter == '[')
            {
                QuoteCharacter = '[';
                OtherQuoteCharacter = ']';
                UseOtherChar = true;
            }
            var sb = new StringBuilder((int)(ObjectName.Length * 1.5) + 2);
            if (QuoteCharacter == '\'' && IsNvarChar)
                sb.Append('N');
            sb.Append(QuoteCharacter); // start with initial quote character
            for (var i = 0; i < ObjectName.Length; i++)
            {
                sb.Append(ObjectName[i]);
                // if its a quote character, add it again e.g. ] becomes ]]
                if (ObjectName[i] == QuoteCharacter || UseOtherChar && ObjectName[i] == OtherQuoteCharacter)
                    sb.Append(ObjectName[i]);
            }
            sb.Append(UseOtherChar ? OtherQuoteCharacter : QuoteCharacter); // finish with other final quote character
            return sb.ToString();
        }
