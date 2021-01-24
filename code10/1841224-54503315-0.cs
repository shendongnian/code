    public static class PhraseExtensions
    {
        public static bool AllViewed(this List<Phrase> phrases)
        {
            return !phrases.Any(p => !p.Viewed);
            // phrases.All(p => p.Viewed); would be better suited.
        }
    }
