    var query = new QueryableWrapper<string>(
        from str in myDataSource
        select str);
    Debug.WriteLine("HasExecuted: " + query.HasExecuted.ToString());
    foreach (string str in query)
    {
        Debug.WriteLine(str);
    }
    Debug.WriteLine("HasExecuted: " + query.HasExecuted.ToString());
