    public T Getclass<T>()
        {
            var key = typeof(T).GUID;
            var foundClass= cacheDictionary.FirstOrDefault(x => x.Key == key);
            T item;
            if (foundClass.Equals(default(KeyValuePair<Guid, T>)))
            {
                item = new T()
                cacheDictionary.Add(key, item);
            }
            else
                item = result.Value;
            return item;
        }
