    public IEnumerator<TObject> GetEnumerator()
    {
        for (var i = items.Count - 1; i >= 0; i--)
        { 
            yield return items[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
