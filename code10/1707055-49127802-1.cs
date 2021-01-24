    public static List<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
    {
        using (var context = GetContext())
        {
            IQueryable<T> dbQuery = context.Set<T>();
            if (null != navigationProperties)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                {
                    dbQuery = dbQuery.Include(navigationProperty);
                }
            }
            if (null == where)
            {
                where = arg => true;
            }
            return dbQuery
                .Where(x => x.Date_Deleted == null 
                         && x.End_Validity == null
                         && where(x))
                .ToList();
        }
    }
