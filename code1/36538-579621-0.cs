        class Set<T> : SortedDictionary<T, bool>
        {
            public void Add(T item)
            {
                this.Add(item, true);
            }
        }
