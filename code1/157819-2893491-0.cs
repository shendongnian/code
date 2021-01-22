    public IEnumerable<T> GetAllNonNullAs(this X x)
    {
        return from pi in x.GetType().GetProperties()
               let val = pi.GetValue(x, null)
               where val != null
               select (T) val;
    }
