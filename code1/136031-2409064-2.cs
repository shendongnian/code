    public class DiacritMerger
    {
        static readonly Dictionary<char, char> _lookup = new Dictionary<char, char>
                             {
                                 {'\'', '\u0301'},
                                 {'"', '\u0308'}
                             };
        public static string Merge(string asciiBase, string diacrits)
        {
            var combined = asciiBase.Zip(diacrits, (ascii, diacrit) => DiacritVersion(diacrit, ascii));
            return new string(combined.ToArray());
        }
        private static char DiacritVersion(char diacrit, char character)
        {
            char combine;
            return _lookup.TryGetValue(diacrit, out combine) ? new string(new [] {character, combine}).Normalize()[0] : character;
        }
    }
