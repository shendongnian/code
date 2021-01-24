    public static class FruitExt {
        static Regex whitespace = new Regex(@"\s", RegexOptions.Compiled);
        public static string FirstWord(this string s) => s.UpTo(whitespace);
        public static bool IsPossessive(this string w) => w.FirstWord().EndsWithOneOf("'s", "'");
    
    
        public static string WithIndefiniteArticle(this string s) => (s.FirstWord().BeginsWithVowelSound() ? "an " : "a ") + s;
        public static string ArticleOrPossessive(this string s) => s.IsPossessive() ? s : s.WithIndefiniteArticle();
    }
