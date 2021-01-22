        /// <summary>
        /// Determines whether a string has more characters to the left of the separator.
        /// </summary>
        /// <param name="a">An arbitrary string, possibly delimited into two parts.</param>
        /// <param name="separator">The characters that partition the string.</param>
        /// <returns>0 if left of the separator has more characters, otherwise returns 1.</returns>
        /// <exception cref="ArgumentException">No separator was supplied.</exception>
        public static int MoreCharactersLeftOfSeparator(string a, string separator)
        {
            if (string.IsNullOrEmpty(separator))
                throw new ArgumentException("No separator was supplied.", "separator");
            if (a == null)
                return 1;
            int separatorIndex = a.LastIndexOf(separator, StringComparison.Ordinal);
            if (separatorIndex == -1)
                return 1;
            int charactersRight = a.Length - separatorIndex - separator.Length;
            if (charactersRight >= separatorIndex)
                return 1;
            return 0;
        }
