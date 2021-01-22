    using System.Collections.Generic;
    namespace HelperMethods
    {
        public static class MergeDictionaries
        {
            public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
            {
                if (second == null) return;
                if (first == null) first = new Dictionary<TKey, TValue>();
                foreach (var item in second) 
                    if (!first.ContainsKey(item.Key)) 
                        first.Add(item.Key, item.Value);
            }
        }
    }
