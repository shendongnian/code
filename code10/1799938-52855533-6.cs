    public List<Word> GetWordsBy<T>(Func<Word,T> orderByPredicate)
    {
        return words.Values.OrderBy(orderBy).ToList();
    }
    public List<Word> GetWordsByName()
    {
        return GetWordsBy(w => w.Name);
    }
