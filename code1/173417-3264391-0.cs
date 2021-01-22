    public IEnumerable<SomeType> YieldMethod(...)
    {
        using(IDbConnection connection = )
        {
            ... 
            using (IDataReader reader = ...)
            {
                while(reader.Read())
                {
                    SomeType someType = ...
                    ...
                    yield return someType;
                }
            }
        }
    }
