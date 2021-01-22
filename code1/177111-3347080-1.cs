    class EntityCollectionBase<T> : List<T> where T : EntityBase, new()
    {
        public void Load()
        {
            // example
            int someId = 14;
            T t = new T();
            t.Load(someId);
            this.Add(t);
        }
    }
