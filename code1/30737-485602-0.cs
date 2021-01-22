    public void Sort<TSource, TKey>(SortOrder sortOrder,
                                    Func<TSource, TKey> keySelector)
    {
        if (sortOrder == SortOrder.Descending)
        {
            _list = _list.OrderByDescending(keySelector).ToList(); 
        }
        else
        {
            _list = _list.OrderBy(keySelector).ToList(); 
        }
    }
