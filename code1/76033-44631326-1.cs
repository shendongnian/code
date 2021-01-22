    public IEnumerable<T> GetResults<T>(SqlDataReader dr) where T : class, new()
    {
        while (dr.Read())
        {
            yield return dr.ConvertToObject<T>());
        }
    }
