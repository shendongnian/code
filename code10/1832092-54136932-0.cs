    public static class StringExt {
        public static double JaroWinklerDistance(this string s1, string s2) => JaroWinkler.proximity(s1, s2);
        
        private static Regex AbbrevSplitRE = new Regex(@" |(?=\p{Lu})", RegexOptions.Compiled);
        public static double AbbrevSimilarity(this string abbrev, string phrase) {
            var phraseWords = phrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return AbbrevSplitRE.Split(abbrev)
                                .Where(aw => !String.IsNullOrEmpty(aw))
                                .Zip(Enumerable.Range(0, phraseWords.Length),
                                     (aw, pwp) => Enumerable.Range(pwp, phraseWords.Length-pwp).Select(n => aw.JaroWinklerDistance(phraseWords[n])).Max()
                                )
                                .Sum() / phraseWords.Length;
        }    
    }
