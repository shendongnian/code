    for(int index=0;index < _collection.Count; index++)
    {
        if (!_collection[index].IsApproved)
        {
            _collection.RemoveAt(index);
            index--;
        }
    }
