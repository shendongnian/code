    public class VowelStatistics
    {
        private readonly string word;
    
        public VowelStatistics(string word)
        {
            this.word = word;
        }
    
        public IEnumerable<char> Vowels => word.Where(c => "aeiouAEIOU".Contains(c));
    
        public int VowelCount => Vowels.Count();
    
        public char MostFrequentVowel => Vowels
            .GroupBy(c => c)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .First();
    
        public int MostFrequentVowelCount => Vowels
            .GroupBy(c => c)
            .Max(g => g.Count());
    }
