    public static class FruitExt {
        public static bool IsPossessive(this string phrase) => phrase.FirstWord().EndsWithOneOf("'s", "'");
    
        public static string WithIndefiniteArticle(this string phrase) => (phrase.FirstWord().BeginsWithVowelSound() ? "an " : "a ") + phrase;
        public static string ArticleOrPossessive(this string phrase) => phrase.IsPossessive() ? phrase : phrase.WithIndefiniteArticle();
    }
