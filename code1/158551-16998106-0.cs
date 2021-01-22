    public static List<TResult> GetSingleColumn<T, TResult>(
       Expression<Func<T, bool>> predicate,
       Expression<Func<T, TResult>> select) where T : class
      {
       using (var db = GetData())
       {
        var q = db.GetTable<T>().AsQueryable();
        if (predicate != null)
         q = q.Where(predicate).AsQueryable();
        var q2 = q.Select(select);
        return q2.ToList();
       }
      }
