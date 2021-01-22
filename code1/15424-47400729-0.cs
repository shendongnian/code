    public static class StringComparerNaturalSortExtension
    {
        public static IComparer<string> WithNaturalSort(this StringComparer stringComparer) => new NaturalSortComparer(stringComparer);
    
        private class NaturalSortComparer : IComparer<string>
        {
            public NaturalSortComparer(StringComparer stringComparer)
            {
                _stringComparer = stringComparer;
            }
    
            private readonly StringComparer _stringComparer;
            private static readonly Regex NumberSequenceRegex = new Regex(@"(\d+)", RegexOptions.Compiled | RegexOptions.CultureInvariant);
            private static string[] Tokenize(string s) => s == null ? new string[] { } : NumberSequenceRegex.Split(s);
            private static ulong ParseNumberOrZero(string s) => ulong.TryParse(s, NumberStyles.None, CultureInfo.InvariantCulture, out var result) ? result : 0;
    
            public int Compare(string s1, string s2)
            {
                var tokens1 = Tokenize(s1);
                var tokens2 = Tokenize(s2);
    
                var zipCompare = tokens1.Zip(tokens2, TokenCompare).FirstOrDefault(x => x != 0);
                if (zipCompare != 0)
                    return zipCompare;
    
                var lengthCompare = tokens1.Length.CompareTo(tokens2.Length);
                return lengthCompare;
            }
            
            private int TokenCompare(string token1, string token2)
            {
                var number1 = ParseNumberOrZero(token1);
                var number2 = ParseNumberOrZero(token2);
    
                var numberCompare = number1.CompareTo(number2);
                if (numberCompare != 0)
                    return numberCompare;
    
                var stringCompare = _stringComparer.Compare(token1, token2);
                return stringCompare;
            }
        }
    }
