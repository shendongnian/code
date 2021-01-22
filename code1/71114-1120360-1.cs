    for (int i = _collection.Count - 1; i >= 0; i--)
    {
        User user = _collection[i];
        if (!user.IsApproved())
        {
            _collection.RemoveAt(i);
        }
    }
