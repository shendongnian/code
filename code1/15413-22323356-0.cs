        public static IEnumerable<string> SortNatural(this IEnumerable<string> strings, StringComparer stringComparer = null)
        {
            var regex = new Regex(@"\d+", RegexOptions.Compiled);
            int maxDigits = strings
                                .SelectMany(s => regex.Matches(s).Cast<Match>().Select(digitChunk => (int?)digitChunk.Value.Length))
                                .Max() ?? 0;
            return strings.OrderBy(i => regex.Replace(i, match => match.Value.PadLeft(maxDigits, '0')), stringComparer ?? StringComparer.CurrentCulture);
        }
