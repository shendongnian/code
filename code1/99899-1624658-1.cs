    public List<Type> GetAll(DateTime? startTime, DateTime? goTime )
    {
        IQueryable<Type> query = DB.TABLENAME;
        if (startTime != null)
        {
            query = query.Where(i => i.startTime >= startTime.Value);
        }
        if (goTime != null)
        {
            query = query.Where(i => i.goTime == goTime.Value);
        }
        return query.ToList();
    }
