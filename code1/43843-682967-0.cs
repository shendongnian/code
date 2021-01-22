    IEnumerable<KeyValuePair<T,U>> Merge<T,U>(IEnumerable<T> keyCollection, IEnumerable<U> valueCollection)
    {
        var keys = keyCollection.GetEnumerator();
        var values = valueCollection.GetEnumerator();
        try
        { 
            keys.Reset();
            values.Reset();
            while (keys.MoveNext() && values.MoveNext())
            {
                yield return new KeyValuePair<T,U>(keys.Current,values.Current);
            }
        }
        finally
        {
            keys.Dispose();
            values.Dispose();
        }
    }
