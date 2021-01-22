    public static class Extensions { 
        /// <summary>
        /// The word categories.
        /// </summary>
        [NotNull]
        private static readonly HashSet<UnicodeCategory> _wordCategories = new HashCollection<UnicodeCategory>(
                    new[]
                    {
                UnicodeCategory.DecimalDigitNumber,
                UnicodeCategory.UppercaseLetter,
                UnicodeCategory.ConnectorPunctuation,
                UnicodeCategory.LowercaseLetter,
                UnicodeCategory.OtherLetter,
                UnicodeCategory.TitlecaseLetter,
                UnicodeCategory.ModifierLetter,
                UnicodeCategory.NonSpacingMark,
                    });
        /// <summary>
        /// Determines whether the specified character is a word character (equivalent to '\w').
        /// </summary>
        /// <param name="c">The c.</param>
        public static bool IsWord(this char c) => _wordCategories.Contains(char.GetUnicodeCategory(c));
    }
