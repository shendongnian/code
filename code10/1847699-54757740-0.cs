    public class BandLevelComponent : IComparable<BandLevelComponent>
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public string Revision { get; private set; }
        public string RomanNumeral { get; private set; }
        private static Dictionary<char, int> _romanMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        private BandLevelComponent()
        {
        }
        public static BandLevelComponent Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            BandLevelComponent result = new BandLevelComponent();
            
            int temp;
            var parts = input.Split('.');
            int.TryParse(parts[0], out temp);
            result.Major = temp;
            if (parts.Length > 1)
            {
                var minor = string.Concat(parts[1].TakeWhile(char.IsNumber));
                int.TryParse(minor, out temp);
                result.Minor = temp;
                if (parts[1].Length > minor.Length)
                {
                    var remaining = parts[1].Substring(minor.Length);
                    var openParen = remaining.IndexOf("(");
                    if (openParen > 0) result.Revision = remaining.Substring(0, openParen);
                    if (openParen > -1)
                        result.RomanNumeral = remaining
                            .Split(new[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries)
                            .Last();
                }
            }
            return result;
        }
        public int CompareTo(BandLevelComponent other)
        {
            if (other == null) return 1;
            if (Major != other.Major) return Major.CompareTo(other.Major);
            if (Minor != other.Minor) return Minor.CompareTo(other.Minor);
            if (Revision != other.Revision) return Revision.CompareTo(other.Revision);
            return RomanNumeral != other.RomanNumeral
                ? RomanToInteger(RomanNumeral).CompareTo(RomanToInteger(other.RomanNumeral))
                : 0;
        }
        public override string ToString()
        {
            var revision = Revision ?? "";
            var roman = RomanNumeral == null ? "" : $"({RomanNumeral})";
            return $"{Major}.{Minor}{revision}{roman}";
        }
        private static int RomanToInteger(string romanNumeral)
        {
            var roman = romanNumeral?.ToUpper();
            var number = 0;
            for (var i = 0; i < roman?.Length; i++)
            {
                if (i + 1 < roman.Length && _romanMap[roman[i]] < _romanMap[roman[i + 1]])
                {
                    number -= _romanMap[roman[i]];
                }
                else
                {
                    number += _romanMap[roman[i]];
                }
            }
            return number;
        }
    }
