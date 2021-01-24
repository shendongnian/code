    List<LovTestData> GetTestData(Expression<Func<T, bool>> where)
    {
        var erg = from p in m_session.Query<LovTestData>()
                  select new
                  {
                   ...
                  }
        IQueryable result = erg.Where(where);
        return result.ToList();   
    }
