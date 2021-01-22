        /// <summary>
        /// Remove all extra spaces and tabs between words in the specified string!
        /// </summary>
        /// <param name="str">The specified string.</param>
        public static string RemoveExtraSpaces(string str)
        {
            str = str.Trim();
            StringBuilder sb = new StringBuilder();
            bool space = false;
            foreach (char c in str)
            {
                if (char.IsWhiteSpace(c) || c == (char)9) { space = true; }
                else { if (space) { sb.Append(' '); }; sb.Append(c); space = false; };
            }
            return sb.ToString();
        }
