    public IEnumerable<T> GetAll<T,K>(Expression<Func<T,K>> sortExpr)
    {
      using (var ctx = new DataContext())
      {
        ctx.ObjectTrackingEnabled = false;
        var table = ctx.GetTable<T>().OrderBy(sortExpr).ToList();
        return table;
      }
    }
