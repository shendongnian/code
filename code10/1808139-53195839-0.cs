    public class Aufgabe
    {
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ";
        public Dictionary<string, int> words;
        public Dictionary<char, List<string>> firstletter;
        public Aufgabe(string filename)
        {
            var text = File.ReadAllText(filename);
            words = Regex.Split(text, @"\W+")
                .GroupBy(m => m, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(m => m.Key, m => m.Count());
            firstletter = ALPHABET.ToDictionary(a => a, // First-letter key
                a => words.Keys.Where(m => a == char.ToUpper(m[0])).ToList()); // Words
        }
    }
