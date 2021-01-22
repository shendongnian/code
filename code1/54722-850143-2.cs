    public void GetSomeData(string filter, Action<IDataReader> processor)
    {
        ...
        
        using (IDataReader rdr = cmd.ExecuteReader())
        {
            processor(rdr);
            
        }
    }
