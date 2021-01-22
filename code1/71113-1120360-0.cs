    for (int i = _collection.Count - 1; i >= 0; i--)
    {
        user User = _collection[i];
        if (!user.IsApproved())
        {
            _collection.RemoveAt(i);
        }
    }
