    public void GetSomeData(string filter, Action<IDataReader> processor)
    {
        ...
        
        using (IDataReader reader = cmd.ExecuteReader())
        {
            processor(reader);
        }
    }
