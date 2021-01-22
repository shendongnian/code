    public static IEnumerable<string> GetIdFields<TEntity>() where TEntity
      : EntityObject
    {
        var ids = from p in typeof(TEntity).GetProperties()
                  where (from a in p.GetCustomAttributes(false)
                         where a is EdmScalarPropertyAttribute &&
                           ((EdmScalarPropertyAttribute)a).EntityKeyProperty
                         select true).FirstOrDefault()
                  select p.Name;
        return ids;
    }
    public static string GetIdField<TEntity>() where TEntity : EntityObject
    {
        IEnumerable<string> ids = GetIdFields<TEntity>();
        string id = ids.Where(s => s.Trim().StartsWith(typeof(TEntity).Name.
                      Trim())).FirstOrDefault();
        if (string.IsNullOrEmpty(id)) id = ids.First();
        return id;
    }
