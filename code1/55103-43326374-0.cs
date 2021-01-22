        public void Add(TKey key, TValue value)
        {
            if (Dictionary.ContainsKey(key))
            {
                int position = IndexOf(key);
                Dictionary.Remove(key);
                Remove(key);
                InsertItem(position, new KeyValuePair<TKey, TValue>(key, value));
                return;
            }
            base.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
