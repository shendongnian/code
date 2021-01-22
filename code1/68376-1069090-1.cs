    public void ConsumeIndexedFunction<T>(Func<string, T> something)
    {
        var foo = something("bar");
        // do something with foo
    }
    public void TestMethod(
        Dictionary<string, object> myDictionary,
        DataTable myDataTable,
        IDataReader myDataReader)
    {
        ConsumeIndexedFunction(x => myDictionary[x]);
        ConsumeIndexedFunction(x => myDataTable.Rows[0][x]);
        ConsumeIndexedFunction(x => myDataReader[x]);
    }
