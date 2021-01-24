    public static class ListExtensions
    {
        public static List<List<T>> PowerSet<T>(this List<T> set)
        {
            var n = set.Count;
            
            var powerSetCount = 1 << n;
            
            var result = new List<List<T>>();
            for (var setMask = 0; setMask < powerSetCount; setMask++)
            {
                var subset = new List<T>();
                for (var i = 0; i < n; i++)
                {
                    if ((setMask & (1 << i)) > 0)
                    {
                        subset.Add(set[i]);
                    }
                }
                result.Add(subset);
            }
            return result;
        }
    }
