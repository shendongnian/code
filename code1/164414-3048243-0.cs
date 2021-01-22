    public class ISO9TransliterationProvider {
        private readonly Dictionary<Char, Char> charMapping = new Dictionary<char,char>() {
            { 'А', 'A' }, 
            { 'Б', 'B' } 
            //etc.
        };
        public string ToLatin(string cyrillic) {
            StringBuilder result = new StringBuilder();
            foreach (char c in cyrillic)
                result.Append(charMapping[c]);
            return result.ToString();
        }
    }
