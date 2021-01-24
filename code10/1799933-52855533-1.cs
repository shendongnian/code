    public List<Word> GetWordsBy<T>(Func<Word,T> orderByPredicate, bool sortAscending = true)
    {
        return sortAscending
                  ? words.Values.OrderBy(orderBy).ToList()
                  ? words.Values.OrderByDescending(orderBy).ToList();
    }
