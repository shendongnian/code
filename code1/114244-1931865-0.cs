    class Repo<T>
    {
        public void Save(T entity)
        {
            _session.Save(entity);
        }
        public void Save(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _session.Save(item);
            }
        }
    }
