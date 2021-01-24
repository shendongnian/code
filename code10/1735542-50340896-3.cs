    public static class CMUDictExt {
        const string cmuFolder = @"D:\";
        static IEnumerable<string> CMUFiles = Directory.EnumerateFiles(cmuFolder, "cmudict-*");
        static Regex cmudictName = new Regex(@"cmudict-(?:\d+(?:\.\d+)?[a-z]?)+\.?(.*)$", RegexOptions.Compiled);
        static string CMUFile(string ext) => CMUFiles.First(f => cmudictName.Match(f).Groups[1].Value == ext);
        
        static Dictionary<string, string> phones;
        static Dictionary<string, string[]> pronunciations;
        public static ILookup<string, string> SymbolWords;
        static HashSet<string> exceptions;
    
        static CMUDictExt() {
            phones = File.ReadLines(CMUFile("phones"))
                         .Select(l => l.Split('\t'))
                         .ToDictionary(pa => pa[0], pa => pa[1]);
    
            pronunciations = File.ReadLines(CMUFile(""))
                                 .Where(l => !l.StartsWith(";;;"))
                                 .Where(l => Char.IsLetter(l[0]))
                                 .Select(l => l.Split("  ").ToArray())
                                 .ToDictionary(wg => wg[0].ToLowerInvariant(), wg => wg[1].Split(' '));
                                 
            SymbolWords = pronunciations.SelectMany(wp => wp.Value.Select(s => (Word: wp.Key, s)))
                                        .ToLookup(wp => wp.s, wp => wp.Word);
            exceptions = pronunciations.Where(wp => (wp.Key.StartsWithVowel() ^ wp.Value[0].Phone() == "vowel")).Select(wp => wp.Key).ToHashSet();
        }
    
        public static string Phone(this string aSymbol) => phones.GetValueOrDefault(aSymbol.UpTo(ch => Char.IsDigit(ch)), String.Empty);
    
        static string[] emptyStringArray = new string[] {};
        public static string[] Pronunciation(this string aWord) => pronunciations.GetValueOrDefault(aWord.ToLowerInvariant(), emptyStringArray);
        public static bool HasPronunciation(this string aWord) => pronunciations.GetValueOrDefault(aWord.ToLowerInvariant(), null) != null;
    
        static readonly HashSet<char> vowels = "aeiou".ToHashSet<char>();
        public static bool StartsWithVowel(this string w) => vowels.Contains(w[0]);
        public static bool BeginsWithVowelSound(this string aWord) => exceptions.Contains(aWord) ? !aWord.StartsWithVowel() : aWord.StartsWithVowel(); // guess if not found
    }
