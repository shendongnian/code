    public static class CollectionSampling
    {
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> coll, int max)
        {
            var rand = new Random();
            using (var enumerator = coll.GetEnumerator());
            {
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current; 
                    int currentSample = rand.Next(max);
                    for (int i = 1; i <= currentSample; i++)
                        enumerator.MoveNext();
                }
            }
        }    
    }
