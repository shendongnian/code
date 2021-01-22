    public void Save<T>(T entity)
    {
        if (typeof(T).GetInterfaces().Contains(typeof(IEnumerable)))
        {
             foreach (var item in entity)
             {
                _session.Save(item);
             }
        }
        else
        {
            _session.Save(entity);
        }
            
    }
