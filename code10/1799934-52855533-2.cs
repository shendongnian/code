    public class WordNameComparer : IComparer<Word>
    {
        public int Compare(Word word1, Word word2)
        {
             return word1.Name.CompareTo(word2.Name);
        }
    }
