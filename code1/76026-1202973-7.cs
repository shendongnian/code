    public IEnumerable<T> GetData<T>(IDataReader reader, Func<IDataRecord, T> BuildObject)
    {
        try
        {
            while (reader.Read())
            {
                yield return BuildObject(reader);
            }
        }
        finally
        {
             reader.Dispose();
        }
    }
    //call it like this:
    var result = GetData(YourLibraryFunction(), Employee.Create);
