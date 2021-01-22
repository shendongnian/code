    public IEnumerable<T> TakeLast<T>(IEnumerable<T> source, int count)
    {
        int i = 0;
        if (count < 1)
            yield break;
        if (source is IList<T> listSource)
        {
            if (listSource.Count < 1)
                yield break;
            for (i = listSource.Count < count ? 0 : listSource.Count - count; i < listSource.Count; i++)
                yield return listSource[i];
        }
        else
        {
            bool move = true;
            bool filled = false;
            T[] result = new T[count];
            using (var enumerator = source.GetEnumerator())
                while (move)
                {
                    for (i = 0; (move = enumerator.MoveNext()) && i < count; i++)
                        result[i] = enumerator.Current;
                    filled |= move;
                }
            if (filled)
                for (int j = i; j < count; j++)
                    yield return result[j];
            for (int j = 0; j < i; j++)
                yield return result[j];
        }
    }
