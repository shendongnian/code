    public static class CollectionExtensions
    {
        public static bool IsOrdered<T>(this IEnumerable<T> collection, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
    
            bool? expectedToIncrease = null;
            using (var enumerator = collection.GetEnumerator())
            {
                bool gotFirst = enumerator.MoveNext();
                if (!gotFirst)
                    return true; // empty collection is ordered
                var first = enumerator.Current;
                T second = default(T);
    
                while (expectedToIncrease is null)
                {
                    bool gotSecond = enumerator.MoveNext();
                    if (!gotSecond)
                        return true; // only equal elements are ordered
                    second = enumerator.Current;
    
                    switch (comparer.Compare(first, second))
                    {
                        case int i when i < 0:
                            expectedToIncrease = false;
                            break;
    
                        case int i when i > 0:
                            expectedToIncrease = true;
                            break;
                    }
    
                    if (expectedToIncrease is null)
                        first = second; // prepare for next round
                }
    
                while (enumerator.MoveNext())
                {
                    if (expectedToIncrease.GetValueOrDefault())
                    {
                        if (comparer.Compare(second, enumerator.Current) < 0)
                            return false;
                    }
                    else
                    {
                        if (comparer.Compare(second, enumerator.Current) > 0)
                            return false;
                    }
                }
                
                return true;
            }
        }
    }
