    public static class ListExtensions
    {        
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> list, Func<T, int> hashCode)
        {
            Dictionary<int, T> hashCodeDic = new Dictionary<int, T>();
            list.ToList().ForEach(t => 
                {   
                    var key = hashCode(t);
                    if (!hashCodeDic.ContainsKey(key))
                        hashCodeDic.Add(key, t);
                });
            return hashCodeDic.Select(kvp => kvp.Value);
        }
    }
 
