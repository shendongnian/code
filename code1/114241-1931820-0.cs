    public void Save<T>(T entity)
    {
        if (T is IEnumerable)
        {
             foreach (var item in entity)
                  _session..Save(item);
        } else  {
            _session.Save(entity);
        }
    }
