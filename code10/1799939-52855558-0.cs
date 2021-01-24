    class WordTable
    {
        public List<Word> GetWords(IComparer<Word> comparer)
        {
            return words.Values.OrderBy(x => x, comparer).ToList();
        }
    }
    class WordsByNameAndThenTypeComparer : IComparer<Word>
    {
        public override int Compare(Word x, Word y)
        {
            int byName = x.Name.CompareTo(y.Name);
            return byName != 0 ? byName : x.Type.CompareTo(y.Type);
        }
    }
