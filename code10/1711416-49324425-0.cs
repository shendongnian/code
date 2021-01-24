    public IQueryable<T> GetActive()
        {
            return DbContext.Set<T>().Where(x => (bool)x.GetType().GetProperty("IsActive").GetValue(x, null) && (string)x.GetType().GetProperty("RecordStatusCode").GetValue(x, null) == "A");
        }
 
