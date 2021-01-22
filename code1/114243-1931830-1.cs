        public void Save<T>(T entity)
        {
            if (typeof(T).GetInterfaces().Contains(typeof(IEnumerable)))
            {
                SaveEnumerable(entity as IEnumerable);
            }
            else
            {
                _session.Save(entity);
            }
        }
        public void SaveEnumerable(IEnumerable entities)
        {
            foreach (var item in entities)
            {
                _session.Save(item);
            }
        }
