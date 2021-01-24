    public static class FruitExt {
        public static readonly HashSet<char> consonants = "bcdfghjklmnpqrstvwxyz".ToHashSet();
        public static bool BeginsWithConsonant(this string w) => consonants.Contains(w[0]);
    
        public static bool IsPossessive(this string w) => w.UpTo(new Regex(@"\s")).EndsWithOneOf("'s", "'");
    
        public static string WithIndefiniteArticle(this string w) => (w.BeginsWithConsonant() ? "a " : "an ") + w;
        public static string ArticleOrPossessive(this string w) => w.IsPossessive() ? w : w.WithIndefiniteArticle();
    }
