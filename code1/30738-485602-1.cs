    public void Sort<TKey>(SortOrder sortOrder,
                           Func<Song, TKey> keySelector)
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
