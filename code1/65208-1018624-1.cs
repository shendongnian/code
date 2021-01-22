    public static IEnumerable<T> GetIndexedItems<T>(this IEnumerable<T> collection, IEnumerable<int> indexes)
    {
        currentIndex = -1;
        using (var collectionEnum = collection.GetEnumerator())
        {
            foreach(int index in indexes)
            {
                while (collectionEnum.MoveNext()) 
                {
                    currentIndex += 1;
                    if (currentIndex == index)
                    {
                        yield return collectionEnum.Current();
                        break;
                    }
                }
            }    
        }
    }
