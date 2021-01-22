    public static IEnumerable<T> GetIndexedItems<T>(this IEnumerable<T> collection, IEnumerable<int> indices)
    {
        int currentIndex = -1;
        using (var collectionEnum = collection.GetEnumerator())
        {
            foreach(int index in indices)
            {
                while (collectionEnum.MoveNext()) 
                {
                    if (++currentIndex == index)
                    {
                        yield return collectionEnum.Current;
                        break;
                    }
                }
            }    
        }
    }
