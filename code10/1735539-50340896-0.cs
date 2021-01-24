    public static class CMUDictExt {
        const string cmuFolder = @"D:\";
        static Dictionary<string, string> phones;
        static Dictionary<string, string[]> pronunciations;
    
        static CMUDictExt() {
            phones = File.ReadLines(Directory.GetFiles(cmuFolder, @"cmudict*.phones").Single())
                         .Select(l => l.Split('\t'))
                         .ToDictionary(pa => pa[0], pa => pa[1]);
    
            pronunciations = File.ReadLines(Directory.GetFiles(cmuFolder, @"cmudict-*").First(f => !f.EndsWithOneOf(".phones", "Symbols")))
                                 .Where(l => !l.StartsWith(";;;"))
                                 .Where(l => Char.IsLetter(l[0]))
                                 .Select(l => l.Split("  ").ToArray())
                                 .ToDictionary(wg => wg[0].ToLowerInvariant(), wg => wg[1].Split(' '));
        }
    
        public static string Phone(this string aSymbol) => phones.GetValueOrDefault(aSymbol.UpTo(ch => Char.IsDigit(ch)), String.Empty);
    
        static string[] emptyStringArray = new string[] {};
        public static string[] Pronunciation(this string aWord) => pronunciations.GetValueOrDefault(aWord.ToLowerInvariant(), emptyStringArray);
        public static bool HasPronunciation(this string aWord) => pronunciations.GetValueOrDefault(aWord.ToLowerInvariant(), null) != null;
    
        static readonly HashSet<char> vowels = "aeiou".ToHashSet<char>();
        public static bool StartsWithVowel(this string w) => vowels.Contains(w[0]);
        public static bool BeginsWithVowelSound(this string aWord) => aWord.HasPronunciation() ? aWord.Pronunciation()[0].Phone() == "vowel" : aWord.StartsWithVowel(); // guess if not found
    }
