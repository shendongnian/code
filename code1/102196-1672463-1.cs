    public static class Extensions
    {
        public static IDictionary<TKey, TValue> ToDictionary2<TKey, TValue>(
            this IEnumerable<TValue> subjects, Func<TValue, TKey> keySelector)
        {
            var dictionary = new Dictionary<TKey, TValue>();
            foreach(var subject in subjects)
            {
                var key = keySelector(subject);
                if(!dictionary.ContainsKey(key))
                    dictionary.Add(key, subject);
            }
            return dictionary;
        }
    }
    var dictionary = list.ToDictionary2(x => x.Name);
