    public static IEnumerable<T> IndexedLookup<T>(
        IEnumerable<int> indexes, IEnumerable<T> items)
    {
        using (var indexesEnum = indexes.GetEnumerator())
        using (var itemsEnum = items.GetEnumerator())
        {
            int currentIndex = -1;
            while (indexesEnum.MoveNext())
            {
                while (currentIndex != indexesEnum.Current)
                {
                    if (!itemsEnum.MoveNext())
                        yield break;
                    currentIndex++;
                }
                yield return itemsEnum.Current;
            }
        }
    }
