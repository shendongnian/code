    public static class IEnumerableExt {
        public static OrderedDictionary ToOrderedDictionary<TKey,TValue,TObj>(this IEnumerable<TObj> src, Func<TObj,TKey> keyFn, Func<TObj, TValue> valueFn) {
            var ans = new OrderedDictionary();
            foreach (var s in src)
                ans.Add(keyFn(s), valueFn(s));
            return ans;
        }    
    }
